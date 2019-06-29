namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class NetworkAttachmentConfig
    {
        public string Target { get; set; }
        public string[] Aliases { get; set; }
        public StringPairs DriverOpts { get; set; }
    }
}
