using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;

namespace AspNetCoreHealthChecks
{
    public class Class2
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHealthChecksUI(options => {
                options.ApiPath = "/healthchecks-api";
                options.UIPath = "/healthchecks-ui";
            });


            app.UseHealthChecks("/hc", new HealthCheckOptions()
            {
                Predicate = (check) => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecks("/hc000", new HealthCheckOptions()
            {
                Predicate = (check) => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecks("/hc001", new HealthCheckOptions()
            {
                Predicate = (check) => check.Tags.Contains("Tag001"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecks("/hc002", new HealthCheckOptions()
            {
                Predicate = (check) => check.Tags.Contains("Tag002"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecks("/hc003", new HealthCheckOptions()
            {
                Predicate = (check) => check.Tags.Contains("Tag003"),
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        }
    }
}
