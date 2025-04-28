using Application.Abstractions.Messaging;
using Application.Metrics.Create;
using SharedKernel;
using Web.API.Extensions;
using Web.API.Infrastructure;

namespace Web.API.Endpoints.Metrics
{
    internal sealed class Post : IEndpoint
    {
        public sealed record Request(
            string MetricName,
            double Value,
            DateTime Timestamp,
            Dictionary<string, string> Tags);

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("metrics", async (Request request, ICommandHandler<CreateMetricsCommand, Result> handler, CancellationToken cancellationToken) =>
            {
                var command = new CreateMetricsCommand
                (
                    request.MetricName,
                    request.Value,
                    request.Timestamp,
                    request.Tags
                );

                var result = await handler.Handle(command, cancellationToken);

                return result.Match(Results.NoContent, CustomResults.Problem);
            })
            .RequireAuthorization();
        }
    }
}
