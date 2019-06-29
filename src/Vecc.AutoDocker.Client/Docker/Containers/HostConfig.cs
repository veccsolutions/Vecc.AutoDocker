using Newtonsoft.Json;

namespace Vecc.AutoDocker.Client.Docker.Containers
{
    public class HostConfig : Resources
    {
        public string[] Binds { get; set; }
        public string ContainerIDFile { get; set; }
        public LogConfig LogConfig { get; set; }
        public string NetworkMode { get; set; }
        public Nats.PortMap PortBindings { get; set; }
        public RestartPolicy RestartPolicy { get; set; }
        public bool AutoRemove { get; set; }
        public string VolumeDriver { get; set; }
        public string[] VolumesFrom { get; set; }
        [JsonProperty("CapAdd")]
        public string[] KernelCapabilitiesAdded { get; set; }

        [JsonProperty("CapDrop")]
        public string[] KernelCapabilitesDropped { get; set; }
        public string[] Capabilities { get; set; }
        public string CgroupnsMode { get; set; }
        public string[] Dns { get; set; }
        public string[] DnsOptions { get; set; }
        public string[] DnsSearch { get; set; }
        public string[] ExtraHosts { get; set; }
        public string[] GroupAdd { get; set; }
        public string IpcMode { get; set; }
        public string Cgroup { get; set; }
        public string[] Links { get; set; }
        public int OomScoreAdj { get; set; }
        public string PidMode { get; set; }
        public bool Privileged { get; set; }
        public bool PublishAllPorts { get; set; }
        public bool ReadonlyRootFs { get; set; }
        public string[] SecurityOpt { get; set; }
        public StringPairs StorageOpt { get; set; }
        public StringPairs Tmpfs { get; set; }
        public string UTSMode { get; set; }
        public string UserNSMode { get; set; }
        public long ShmSize { get; set; }
        public StringPairs Sysctls { get; set; }
        public string Runtime { get; set; }

        public int[] ConsoleSize { get; set; }
        public Isolation Isolation { get; set; }

        public Mounts.Mount[] Mounts { get; set; }
        public string[] MaskedPaths { get; set; }
        public string[] ReadonlyPaths { get; set; }
        public bool? Init { get; set; }
    }
}
