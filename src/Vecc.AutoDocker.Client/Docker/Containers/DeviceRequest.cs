namespace Vecc.AutoDocker.Client.Docker.Containers
{
    public class DeviceRequest
    {
        public string Driver { get; set; }
        public int Count { get; set; }
        public string[] DeviceIDs { get; set; }
        public string[][] Capabilities { get; set; }
        public StringPairs Options { get; set; }
    }
}
