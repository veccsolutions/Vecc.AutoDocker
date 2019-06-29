namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class NodeStatus
    {
        public NodeState State { get; set; }
        public string Message { get; set; }
        public string Addr { get; set; }
    }
}
