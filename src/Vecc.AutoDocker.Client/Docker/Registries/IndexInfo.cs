namespace Vecc.AutoDocker.Client.Docker.Registries
{
    public class IndexInfo
    {
        public string Name { get; set; }
        public string[] Mirrors { get; set; }
        public bool Secure { get; set; }
        public bool Official { get; set; }
    }
}
