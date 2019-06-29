namespace Vecc.AutoDocker.Client.Docker.Swarms.Runtimes
{
    public class PluginSpec
    {
        public string Name { get; set; }
        public string Remote { get; set; }
        public PluginPrivilege[] Privileges { get; set; }
        public bool Disabled { get; set; }
    }
}
