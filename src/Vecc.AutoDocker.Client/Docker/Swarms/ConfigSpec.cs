namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class ConfigSpec : Annotations
    {
        public byte[] Data { get; set; }
        public Driver Templating { get; set; }
    }
}
