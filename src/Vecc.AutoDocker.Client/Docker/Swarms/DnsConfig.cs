namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class DnsConfig
    {
        public string[] Nameservers { get; set; }
        public string[] Search { get; set; }
        public string[] Options { get; set; }
    }
}
