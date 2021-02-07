﻿// Unless explicitly stated otherwise all files in this repository are licensed
// under the Apache License Version 2.0.
// This product includes software developed at Datadog (https://www.datadoghq.com/).
// Copyright 2019 Datadog, Inc.

using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Serilog.Sinks.Datadog.Logs
{
    /// <summary>
    ///     Configures the sink's DatadogConfiguration object.
    /// </summary>
    internal static class ApplyMicrosoftExtensionsConfiguration
    {
        /// <summary>
        ///     Create the DatadogConfiguration object or apply any configuration changes to it.
        /// </summary>
        /// <param name="datadogConfiguration">
        ///     An optional externally-created DatadogConfiguration object to be updated with
        ///     additional configuration values.
        /// </param>
        /// <param name="config">A configuration section typically named "configurationSection".</param>
        /// <returns>The "merged" DatadogConfiguration object.</returns>
        internal static DatadogConfiguration ConfigureDatadogConfiguration(DatadogConfiguration datadogConfiguration,
            IConfigurationSection configurationOption)
        {
            if (configurationOption == null || !configurationOption.GetChildren().Any())
                return datadogConfiguration ?? new DatadogConfiguration();

            var section = configurationOption.Get<DatadogConfiguration>();

            return new DatadogConfiguration(
                datadogConfiguration?.Url ?? section.Url,
                datadogConfiguration?.Port ?? section.Port,
                datadogConfiguration?.UseSSL ?? section.UseSSL,
                datadogConfiguration?.UseTCP ?? section.UseTCP
            );
        }
    }
}