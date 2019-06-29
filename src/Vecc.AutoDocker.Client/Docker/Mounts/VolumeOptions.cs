namespace Vecc.AutoDocker.Client.Docker.Mounts
{
    public class VolumeOptions
    {
        public bool NoCopy { get; set; }
        public StringPairs Labels { get; set; }
        public Driver DriverConfig { get; set; }
    }
}
