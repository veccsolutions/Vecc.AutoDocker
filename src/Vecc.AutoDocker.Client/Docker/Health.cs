namespace Vecc.AutoDocker.Client.Docker
{
    public class Health
    {
        public string Status { get; set; }
        public int FailingStreak { get; set; }
        public HealthCheckResult[] Log { get; set; }
    }
}
