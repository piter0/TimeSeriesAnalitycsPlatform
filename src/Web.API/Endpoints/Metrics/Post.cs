using Application.Abstractions.Messaging;
using Application.Metrics.Create;
using SharedKernel;
using Web.API.Extensions;
using Web.API.Infrastructure;

namespace Web.API.Endpoints.Metrics
{
    internal sealed class Post : IEndpoint
    {
        public sealed class Request
        {
            public string Metric { get; set; }
            public double Value { get; set; }
            public DateTime Timestamp { get; set; }
            public Dictionary<string, string> Tags { get; set; }
        }

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("metrics", async (Request request, ICommandHandler<CreateMetricsCommand, Result> handler, CancellationToken cancellationToken) =>
            {
                var command = new CreateMetricsCommand
                {
                    Metric = request.Metric,
                    Value = request.Value,
                    Timestamp = request.Timestamp,
                    Tags = request.Tags,
                };

                var result = await handler.Handle(command, cancellationToken);

                return result.Match(Results.NoContent, CustomResults.Problem);
            })
            .RequireAuthorization();
        }
    }
}
