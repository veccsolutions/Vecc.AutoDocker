namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class Info
    {
        public string NodeId { get; set; }
        public string NodeAddr { get; set; }
        public LocalNodeState LocalNodeState { get; set; }
        public bool ControlAvailable { get; set; }
        public string Error { get; set; }
        public Peer[] RemoteManagers { get; set; }
        public int Nodes { get; set; }
        public int Managers { get; set; }
        public ClusterInfo Cluster { get; set; }
        public string[] Warnings { get; set; }
    }
}
