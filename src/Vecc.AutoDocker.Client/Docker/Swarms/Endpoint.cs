namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class Endpoint
    {
        public EndpointSpec Spec { get; set; }
        public PortConfig[] Ports { get; set; }
        public EndpointVirtualIP[] VirtualIPs { get; set; }
    }
}
