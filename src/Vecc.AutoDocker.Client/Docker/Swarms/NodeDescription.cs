namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class NodeDescription
    {
        public string Hostname { get; set; }
        public Platform Platform { get; set; }
        public Resources Resources { get; set; }
        public EngineDescription Engine { get; set; }
        public TLSInfo TLSInfo { get; set; }
    }
}
