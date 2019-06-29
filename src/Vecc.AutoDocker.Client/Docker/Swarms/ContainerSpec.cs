namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class ContainerSpec
    {
        public string Image { get; set; }
        public StringPairs Labels { get; set; }
        public string[] Command { get; set; }
        public string[] Args { get; set; }
        public string Hostname { get; set; }
        public string[] Env { get; set; }
        public string Dir { get; set; }
        public string User { get; set; }
        public string[] Groups { get; set; }
        public Privileges Privileges { get; set; }
        public bool? Init { get; set; }
        public string StopSignal { get; set; }
        public bool TTY { get; set; }
        public bool OpenStdin { get; set; }
        public bool ReadOnly { get; set; }
        public Mounts.Mount[] Mounts { get; set; }
        public long? StopGracePeriod { get; set; }
        public Containers.HealthConfig HealthCheck { get; set; }
        public string[] Hosts { get; set; }
        public DnsConfig DnsConfig { get; set; }
        public SecretReference[] Secrets { get; set; }
        public ConfigReference[] Configs { get; set; }
        public Containers.Isolation Isolation { get; set; }
        public StringPairs Sysctls { get; set; }
        public string[] Capabilities { get; set; }
    }
}
