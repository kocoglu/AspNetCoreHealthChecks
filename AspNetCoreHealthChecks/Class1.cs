using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AspNetCoreHealthChecks
{
    public class Class1
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks()
                        .AddCheck("Health Check UI - Zero", () => HealthCheckResult.Healthy())
                        .AddCheck("Health Check UI - 001", () => HealthCheckResult.Healthy(), tags: new[] { "Tag001" })
                        .AddCheck("Health Check UI - 002", () => HealthCheckResult.Healthy(), tags: new[] { "Tag002" })
                        .AddCheck("Health Check UI - 003", () => HealthCheckResult.Healthy(), tags: new[] { "Tag003" })
                        .AddCheck("Health Check UI - 004", () => HealthCheckResult.Healthy(), tags: new[] { "Tag001", "Tag002", "Tag003" })
                        .AddCheck("Health Check UI - 005", () => new Random().Next(1, 4) % 2 == 0 ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy());

            services
                .AddHealthChecksUI(setup =>
                {
                    setup.MaximumHistoryEntriesPerEndpoint(50);
                    setup.SetEvaluationTimeInSeconds(10);

                    setup.AddHealthCheckEndpoint("Health Check Zero", "https://localhost:44339/hc");
                    setup.AddHealthCheckEndpoint("Health Check 000", "https://localhost:44339/hc000");
                    setup.AddHealthCheckEndpoint("Health Check 001", "https://localhost:44339/hc001");
                    setup.AddHealthCheckEndpoint("Health Check 002", "https://localhost:44339/hc002");
                    setup.AddHealthCheckEndpoint("Health Check 003", "https://localhost:44339/hc003");
                })
                .AddSqliteStorage("Data Source = SQLite.db");
        }
    }
}
