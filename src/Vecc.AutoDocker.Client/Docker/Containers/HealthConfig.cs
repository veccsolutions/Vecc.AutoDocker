namespace Vecc.AutoDocker.Client.Docker.Containers
{
    public class HealthConfig
    {
        public string[] Test { get; set; }
        public long? Interval { get; set; }
        public long? Timeout { get; set; }
        public long? StartPeriod { get; set; }
        public int? Retries { get; set; }
    }
}
