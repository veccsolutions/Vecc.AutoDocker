namespace Vecc.AutoDocker.Client.Docker.Networks
{
    public class IPAMConfig
    {
        public string Subnet { get; set; }
        public string IPRange { get; set; }
        public string Gateway { get; set; }
        public StringPairs AuxAddress { get; set; }
    }
}
