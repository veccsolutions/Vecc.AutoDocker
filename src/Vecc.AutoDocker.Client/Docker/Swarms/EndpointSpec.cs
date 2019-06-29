namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class EndpointSpec
    {
        public ResolutionMode Mode { get; set; }
        public PortConfig[] Ports { get; set; }
    }
}
