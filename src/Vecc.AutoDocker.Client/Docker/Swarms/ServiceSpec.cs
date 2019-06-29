namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class ServiceSpec : Annotations
    {
        public TaskSpec TaskTemplate { get; set; }
        public ServiceMode Mode { get; set; }
        public UpdateConfig UpdateConfig { get; set; }
        public UpdateConfig RollbackConfig { get; set; }
        public NetworkAttachmentConfig[] Networks { get; set; }
        public EndpointSpec EndpointSpec { get; set; }
    }
}
