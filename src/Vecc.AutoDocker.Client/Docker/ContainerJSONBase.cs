namespace Vecc.AutoDocker.Client.Docker
{
    public class ContainerJSONBase
    {
        public string Id { get; set; }
        public string Created { get; set; }
        public string Path { get; set; }
        public string[] Args { get; set; }
        public ContainerState State { get; set; }
        public string Image { get; set; }
        public string ResolvConfPath { get; set; }
        public string HostnamePath { get; set; }
        public string HostsPath { get; set; }
        public string LogPath { get; set; }
        public ContainerNode Node { get; set; }
        public string Name { get; set; }
        public int RestartCount { get; set; }
        public string Driver { get; set; }
        public string Platform { get; set; }
        public string MountLabel { get; set; }
        public string ProcessLabel { get; set; }
        public string[] ExecIDs { get; set; }
        public Containers.HostConfig HostConfig { get; set; }
        public GraphDriverData GraphDriverData { get; set; }
        public long? SizeRw { get; set; }
        public long? SizeRootFs { get; set; }
    }
}
