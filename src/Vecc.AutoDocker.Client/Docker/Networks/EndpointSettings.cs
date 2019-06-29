namespace Vecc.AutoDocker.Client.Docker.Networks
{
    public class EndpointSettings
    {
        public EndpointIPAMConfig IPAMConfig { get; set; }
        public string[] Links { get; set; }
        public string[] Aliases { get; set; }
        public string NetworkId { get; set; }
        public string ENdpointId { get; set; }
        public string IPAddress { get; set; }
        public int IPPrefixLen { get; set; }
        public string IPv6Gateway { get; set; }
        public string GlobalIPv6Address { get; set; }
        public string GlobalIPv6PrefixLen { get; set; }
        public string MacAddress { get; set; }
        public StringPairs DriverOpts { get; set; }
    }
}
