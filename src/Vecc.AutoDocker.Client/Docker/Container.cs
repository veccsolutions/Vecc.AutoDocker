namespace Vecc.AutoDocker.Client.Docker
{
    public class Container
    {
        public string Id { get; set; }
        public string[] Names { get; set; }
        public string Image { get; set; }
        public string ImageID { get; set; }
        public string Command { get; set; }
        public long Created { get; set; }
        public Port[] Ports { get; set; }
        public long SizeRW { get; set; }
        public long SizeRootFs { get; set; }
        public StringPairs Labels { get; set; }
        public string State { get; set; }
        public string Status { get; set; }
        public HostNetworkConfig HostConfig { get; set; }
        public SummaryNetworkSettings NetworkSettings { get; set; }
        public MountPoint[] Mounts { get; set; }

        public class HostNetworkConfig
        {
            public string NetworkMode { get; set; }
        }
    }
}
