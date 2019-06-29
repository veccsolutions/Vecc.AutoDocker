namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class PortConfig
    {
        public string Name { get; set; }
        public PortConfigProtocol? Protocol { get; set; }
        public int? TargetPort { get; set; }
        public int? PublishedPort { get; set; }
        public PortConfigPublishMode? PublishMode { get; set; }
    }
}
