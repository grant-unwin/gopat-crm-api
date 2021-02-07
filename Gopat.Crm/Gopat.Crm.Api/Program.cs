using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Datadog.Logs;


namespace Gopat.Crm.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithEnvironmentUserName()
                .Enrich.WithEnvironmentName()
                .Enrich.WithProperty("ApplicationName", "GoPat CRM API")
                .WriteTo.DatadogLogs("3d993d44bc3c102bf66e7ef179054cab", configuration: new DatadogConfiguration
                {
                    Url = "https://http-intake.logs.datadoghq.eu"
                }, exceptionHandler: e =>
                {
                    if (e is CannotSendLogEventException cannotSendLogEventException)
                        Console.WriteLine(
                            $"ERROR: {cannotSendLogEventException}  LogEvents Count: {cannotSendLogEventException.LogEvents.Count()}");
                })
                .CreateLogger();

            try
            {
                Log.Information("Starting web host");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog(Log.Logger)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
