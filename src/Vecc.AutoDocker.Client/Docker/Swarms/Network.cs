namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class Network : Meta
    {
        public string Id { get; set; }
        public NetworkSpec Spec { get; set; }
        public Driver DriverState { get; set; }
        public IPAMOptions IPAMOptions { get; set; }
    }
}
