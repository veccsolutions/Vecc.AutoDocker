namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class ContainerStatus
    {
        public string ContainerId { get; set; }
        public int Pid { get; set; }
        public int ExitCode { get; set; }
    }
}
