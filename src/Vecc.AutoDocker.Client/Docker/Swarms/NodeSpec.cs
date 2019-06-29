namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class NodeSpec : Annotations
    {
        public NodeRole Role { get; set; }
        public NodeAvailability Availability { get; set; }
    }
}
