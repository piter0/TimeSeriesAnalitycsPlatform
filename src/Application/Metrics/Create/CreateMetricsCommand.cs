using Application.Abstractions.Messaging;
using FluentValidation;
using SharedKernel;

namespace Application.Metrics.Create
{
    public sealed record CreateMetricsCommand(
            string MetricName,
            double Value,
            DateTime Timestamp,
            Dictionary<string, string> Tags) : ICommand;

    public sealed class CreateMetricsCommandValidator : AbstractValidator<CreateMetricsCommand>
    {
        public CreateMetricsCommandValidator()
        {
            RuleFor(c => c.MetricName).NotEmpty();
        }
    }

    internal sealed class CreateMetricsCommandHandler() : ICommandHandler<CreateMetricsCommand, Result>
    {
        public async Task<Result> Handle(CreateMetricsCommand command, CancellationToken cancellationToken)
        {
            await Task.Delay(1000, cancellationToken);
            return Result.Success();
        }
    }
}
