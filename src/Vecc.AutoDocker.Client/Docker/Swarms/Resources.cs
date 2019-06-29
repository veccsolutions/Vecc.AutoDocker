namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class Resources
    {
        public long? NanoCpus { get; set; }
        public long? MemoryBytes { get; set; }
        public GenericResource[] GenericResources { get; set; }
    }
}
