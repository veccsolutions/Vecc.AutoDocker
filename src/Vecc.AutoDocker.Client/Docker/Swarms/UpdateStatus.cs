using System;

namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class UpdateStatus
    {
        public UpdateState State { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string Message { get; set; }
    }
}
