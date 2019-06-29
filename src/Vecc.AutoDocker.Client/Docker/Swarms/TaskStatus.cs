using System;

namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class TaskStatus
    {
        public DateTime Timestamp { get; set; }
        public TaskState State { get; set; }
        public string Message { get; set; }
        public string Err { get; set; }
        public ContainerStatus ContainerStatus { get; set; }
        public PortStatus PortStatus { get; set; }
    }
}
