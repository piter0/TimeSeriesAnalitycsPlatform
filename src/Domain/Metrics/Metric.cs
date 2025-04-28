using SharedKernel;

namespace Domain.Metrics
{
    public sealed class Metric : Entity
    {
        public string MetricName { get; set; }
        public double Value { get; set; }
        public DateTime Timestamp { get; set; }
        public Dictionary<string, string> Tags { get; set; }
    }
}
