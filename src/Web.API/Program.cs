using HealthChecks.UI.Client;
using Infrastructure;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;
using System.Reflection;
using Web.API.Extensions;

namespace Web.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));

            builder.Services.AddAuthorization();

            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

            var app = builder.Build();

            app.MapEndpoints();

            app.MapHealthChecks("health", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.Run();
        }
    }
}
