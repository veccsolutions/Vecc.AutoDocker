namespace Vecc.AutoDocker.Client.Docker.Networks
{
    public class IPAM
    {
        public string Driver { get; set; }
        public StringPairs Options { get; set; }
        public IPAMConfig[] Config { get; set; }
    }
}
