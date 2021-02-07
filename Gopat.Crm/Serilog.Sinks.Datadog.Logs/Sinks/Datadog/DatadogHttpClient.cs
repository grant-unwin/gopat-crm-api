﻿// Unless explicitly stated otherwise all files in this repository are licensed
// under the Apache License Version 2.0.
// This product includes software developed at Datadog (https://www.datadoghq.com/).
// Copyright 2019 Datadog, Inc.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Serilog.Events;

namespace Serilog.Sinks.Datadog.Logs
{
    public class DatadogHttpClient : IDatadogClient
    {
        private const string _content = "application/json";
        private const int _maxSize = 2 * 1024 * 1024 - 51; // Need to reserve space for at most 49 "," and "[" + "]"
        private const int _maxMessageSize = 256 * 1024;

        /// <summary>
        ///     Max number of retries when sending failed.
        /// </summary>
        private const int MaxRetries = 10;

        /// <summary>
        ///     Max backoff used when sending failed.
        /// </summary>
        private const int MaxBackoff = 30;

        /// <summary>
        ///     Shared UTF8 encoder.
        /// </summary>
        private static readonly UTF8Encoding UTF8 = new UTF8Encoding();

        private readonly HttpClient _client;

        private readonly DatadogConfiguration _config;
        private readonly LogFormatter _formatter;
        private readonly string _url;

        public DatadogHttpClient(DatadogConfiguration config, LogFormatter formatter, string apiKey)
        {
            _config = config;
            _client = new HttpClient();
            _url = $"{config.Url}/v1/input/{apiKey}";
            _formatter = formatter;
        }

        public Task WriteAsync(IEnumerable<LogEvent> events)
        {
            var serializedEvents = SerializeEvents(events);
            var tasks = serializedEvents.LogEventChunks.Select(Post);

            var tooBigTask = Task.Run(() =>
            {
                if (serializedEvents.TooBigLogEvents.Count > 0)
                    throw new TooBigLogEventException(serializedEvents.TooBigLogEvents);
            });

            tasks = tasks.Concat(new[] {tooBigTask});

            return Task.WhenAll(tasks);
        }

        void IDatadogClient.Close()
        {
        }

        private SerializedEvents SerializeEvents(IEnumerable<LogEvent> events)
        {
            var serializedEvents = new SerializedEvents();
            var currentSize = 0;

            var chunkBuffer = new List<string>(events.Count());
            var logEvents = new List<LogEvent>(events.Count());
            foreach (var logEvent in events)
            {
                var formattedLog = _formatter.formatMessage(logEvent);
                var logSize = Encoding.UTF8.GetByteCount(formattedLog);
                if (logSize > _maxMessageSize)
                {
                    serializedEvents.TooBigLogEvents.Add(logEvent);
                    continue; // The log is dropped because the backend would not accept it
                }

                if (currentSize + logSize > _maxSize)
                {
                    // Flush the chunkBuffer to the chunks and reset the chunkBuffer
                    serializedEvents.LogEventChunks.Add(GenerateChunk(chunkBuffer, ",", "[", "]", logEvents));
                    chunkBuffer.Clear();
                    logEvents.Clear();
                    currentSize = 0;
                }

                chunkBuffer.Add(formattedLog);
                logEvents.Add(logEvent);
                currentSize += logSize;
            }

            if (chunkBuffer.Count != 0)
                serializedEvents.LogEventChunks.Add(GenerateChunk(chunkBuffer, ",", "[", "]", logEvents));

            return serializedEvents;
        }

        private static LogEventChunk GenerateChunk(IEnumerable<string> collection, string delimiter, string prefix,
            string suffix, IEnumerable<LogEvent> logEvents)
        {
            return new LogEventChunk
            {
                Payload = prefix + string.Join(delimiter, collection) + suffix,
                LogEvents = new List<LogEvent>(logEvents) // Copy `logEvents` as `logEvents` is reused.
            };
        }

        private async Task Post(LogEventChunk logEventChunk)
        {
            var payload = logEventChunk.Payload;
            var content = new StringContent(payload, Encoding.UTF8, _content);
            var responses = new List<HttpResponseMessage>();

            for (var retry = 0; retry < MaxRetries; retry++)
            {
                var backoff = (int) Math.Min(Math.Pow(2, retry), MaxBackoff);
                if (retry > 0) await Task.Delay(backoff * 1000);

                try
                {
                    var result = await _client.PostAsync(_url, content);
                    if (result == null) continue;

                    responses.Add(result);

                    if ((int) result.StatusCode >= 500) continue;
                    if ((int) result.StatusCode >= 400) break;
                    if (result.IsSuccessStatusCode) return;
                }
                catch (Exception)
                {
                }
            }

            throw new CannotSendLogEventException(payload, logEventChunk.LogEvents, responses);
        }

        private class LogEventChunk
        {
            public string Payload { get; set; }
            public IEnumerable<LogEvent> LogEvents { get; set; }
        }

        private class SerializedEvents
        {
            public List<LogEventChunk> LogEventChunks { get; } = new List<LogEventChunk>();
            public List<LogEvent> TooBigLogEvents { get; } = new List<LogEvent>();
        }
    }
}