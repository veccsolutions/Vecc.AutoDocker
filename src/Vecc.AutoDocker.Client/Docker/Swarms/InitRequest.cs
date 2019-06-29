namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class InitRequest
    {
        public string ListenAddr { get; set; }
        public string AdvertiseAddr { get; set; }
        public string DataPathAddr { get; set; }
        public string DataPathPort { get; set; }
        public bool ForceNewCluster { get; set; }
        public Spec Spec { get; set; }
        public bool AutoLockManagers { get; set; }
        public NodeAvailability Availability { get; set; }
        public string[] DefaultAddrPool { get; set; }
        public int SubnetSize { get; set; }
    }
}
