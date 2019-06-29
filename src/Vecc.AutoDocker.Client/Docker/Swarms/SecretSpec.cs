namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class SecretSpec : Annotations
    {
        public byte[] Data { get; set; }
        public Driver Driver { get; set; }
        public Driver Templating { get; set; }
    }
}
