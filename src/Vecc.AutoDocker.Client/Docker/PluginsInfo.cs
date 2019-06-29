namespace Vecc.AutoDocker.Client.Docker
{
    public class PluginsInfo
    {
        public string[] Volume { get; set; }
        public string[] Networks { get; set; }
        public string[] Authorization { get; set; }
        public string[] Log { get; set; }
    }
}
