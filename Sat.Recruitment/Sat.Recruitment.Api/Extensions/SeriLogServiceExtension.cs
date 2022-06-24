using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace Sat.Recruitment.Api.Extensions
{
    public static class SeriLogServiceExtension
    {
        public static void ConfigureLogger(this WebApplicationBuilder builder)
        {
            var conf = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .WriteTo.Console()
                .WriteTo.Elasticsearch(
                    new ElasticsearchSinkOptions(new Uri(builder.Configuration.GetValue<string>("ElasticConfiguration:Uri")))
                    {
                        IndexFormat = $"applogs-{builder.Environment.ApplicationName?.ToLower().Replace(".", "-")}-{builder.Environment.EnvironmentName?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                        AutoRegisterTemplate = true,
                        NumberOfShards = 2,
                        NumberOfReplicas = 1
                    }
                )
                .Enrich.WithProperty("Environment", builder.Environment.EnvironmentName)
                .Enrich.WithProperty("Application", builder.Environment.ApplicationName)
                .ReadFrom.Configuration(conf)
                .CreateLogger();

            builder.Logging.AddSerilog(Log.Logger);

        }
    }
}
