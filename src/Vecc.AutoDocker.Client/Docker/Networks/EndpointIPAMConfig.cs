namespace Vecc.AutoDocker.Client.Docker.Networks
{
    public class EndpointIPAMConfig
    {
        public string IPv4Address { get; set; }
        public string IPv6Address { get; set; }
        public string[] LinkLocalIPs { get; set; }
    }
}
