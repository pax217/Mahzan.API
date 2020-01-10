using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;

namespace Mahzan.Api.Extensions
{
    public static class HealthChecksExtension
    {
        public static void ConfigureHealthChecks(this IApplicationBuilder app)
        {
            var options = new HealthCheckOptions
            {
                Predicate = check => check.Tags.Contains("ready"),
                ResponseWriter = HealthResponseWriter
            };

            options.ResultStatusCodes[HealthStatus.Unhealthy] = StatusCodes.Status500InternalServerError;

            app.UseHealthChecks("/health", options);

            var pingOptions = new HealthCheckOptions
            {
                ResponseWriter = HealthResponseWriter,
                Predicate = check => false
            };

            pingOptions.ResultStatusCodes[HealthStatus.Unhealthy] = StatusCodes.Status500InternalServerError;

            app.UseHealthChecks("/ping", pingOptions);
        }

        /// <summary>
        /// Health response writer.
        /// </summary>
        /// <param name="context">Http context.</param>
        /// <param name="healthReport">Health report.</param>
        /// <returns>The async.</returns>
        private static Task HealthResponseWriter(HttpContext context, HealthReport healthReport)
        {
            var serializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            Task WriteResponse(HealthStatusResponse response)
            {
                return context.Response.WriteAsync(
                    JsonConvert.SerializeObject(
                        response,
                        serializerSettings
                    )
                );
            }

            context.Response.ContentType = "application/json";

            switch (healthReport.Status)
            {
                case HealthStatus.Healthy:
                    return WriteResponse(new HealthStatusResponse
                    {
                        Status = HttpStatusCode.OK.ToString(),
                        Version = GetAssemblyVersion()
                    });
                case HealthStatus.Unhealthy:
                    return WriteResponse(new HealthStatusResponse
                    {
                        Status = "internal_server_error",
                        Version = GetAssemblyVersion(),
                        Errors = healthReport.Entries
                    });
                default:
                    return WriteResponse(new HealthStatusResponse
                    {
                        Status = "internal_server_error",
                        Version = GetAssemblyVersion()
                    });
            }
        }

        /// <summary>
        /// Get the version of the assembly.
        /// </summary>
        /// <returns>Version.</returns>
        private static string GetAssemblyVersion()
        {
            return typeof(HealthChecksExtension).Assembly.GetName().Version.ToString();
        }
    }

    class HealthStatusResponse
    {
        public string Status { get; set; }
        public string Version { get; set; }
        public IReadOnlyDictionary<string, HealthReportEntry> Errors { get; set; }
    }
}
