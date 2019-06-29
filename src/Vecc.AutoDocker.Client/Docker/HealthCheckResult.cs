using System;

namespace Vecc.AutoDocker.Client.Docker
{
    public class HealthCheckResult
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int ExitCode { get; set; }
        public string Output { get; set; }
    }
}
