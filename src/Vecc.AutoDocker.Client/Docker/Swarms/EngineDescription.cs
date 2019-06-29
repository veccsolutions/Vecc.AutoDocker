namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class EngineDescription
    {
        public string EngineVersion { get; set; }
        public StringPairs Labels { get; set; }
        public PluginDescription[] Plugins { get; set; }
    }
}
