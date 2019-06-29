namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class Node : Meta
    {
        public string Id { get; set; }
        public NodeSpec Spec { get; set; }
        public NodeDescription Description { get; set; }
        public NodeStatus Status { get; set; }
        public ManagerStatus ManagerStatus { get; set; }
    }
}
