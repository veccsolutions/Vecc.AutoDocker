namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class NetworkSpec : Annotations
    {
        public Driver DriverConfiguration { get; set; }
        public bool IPv6Enabled { get; set; }
        public bool Internal { get; set; }
        public bool Attachable { get; set; }
        public bool Ingress { get; set; }
        public IPAMOptions IPAMOptions { get; set; }
        public Networks.ConfigReference ConfigFrom { get; set; }
        public string Scope { get; set; }
    }
}
