namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class ClusterInfo : Meta
    {
        public string Id { get; set; }
        public Spec Spec { get; set; }
        public TLSInfo TLSInfo { get; set; }
        public bool RootRotationInProgress { get; set; }
        public string[] DefaultAddrPool { get; set; }
        public int SubnetSize { get; set; }
        public int DataPathPort { get; set; }
    }
}
