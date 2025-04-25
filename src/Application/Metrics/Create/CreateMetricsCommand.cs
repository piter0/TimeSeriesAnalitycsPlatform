using Application.Abstractions.Messaging;
using FluentValidation;
using SharedKernel;

namespace Application.Metrics.Create
{
    public sealed class CreateMetricsCommand : ICommand
    {
        public string Metric { get; set; }
        public double Value { get; set; }
        public DateTime Timestamp { get; set; }
        public Dictionary<string, string> Tags { get; set; }
    }

    public sealed class CreateMetricsCommandValidator : AbstractValidator<CreateMetricsCommand>
    {
        public CreateMetricsCommandValidator()
        {
            RuleFor(c => c.Metric).NotEmpty();
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
