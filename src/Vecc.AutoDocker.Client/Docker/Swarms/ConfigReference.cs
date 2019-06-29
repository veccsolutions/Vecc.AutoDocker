namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class ConfigReference
    {
        public ConfigReferenceFileTarget File { get; set; }
        public ConfigReferenceRuntimeTarget Runtime { get; set; }
        public string ConfigId { get; set; }
        public string ConfigName { get; set; }
    }
}
