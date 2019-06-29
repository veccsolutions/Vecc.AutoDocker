namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class TaskSpec
    {
        public ContainerSpec ContainerSpec { get; set; }
        public Runtimes.PluginSpec PluginSpec { get; set; }
        public NetworkAttachmentSpec NetworkAttachmentSpec { get; set; }
        public ResourceRequirements Resources { get; set; }
        public RestartPolicy RestartPolicy { get; set; }
        public Placement Placement { get; set; }
        public NetworkAttachmentConfig[] Networks { get; set; }
        public Driver LogDriver { get; set; }
        public long ForceUpdate { get; set; }
        public string Runtime { get; set; }
    }
}
