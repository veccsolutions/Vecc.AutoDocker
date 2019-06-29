namespace Vecc.AutoDocker.Client.Docker
{
    public class NetworkCreate
    {
        public bool CheckDuplicate { get; set; }
        public string Driver { get; set; }
        public bool EnableIPv6 { get; set; }
        public Networks.IPAM IPAM { get; set; }
        public bool Internal { get; set; }
        public bool Attachable { get; set; }
        public bool Ingres { get; set; }
        public bool ConfigOnly { get; set; }
        public Networks.ConfigReference ConfigFrom { get; set; }
        public StringPairs Options { get; set; }
        public StringPairs Labels { get; set; }
    }
}
