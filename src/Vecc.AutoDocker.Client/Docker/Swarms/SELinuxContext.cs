namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class SELinuxContext
    {
        public bool Disable { get; set; }
        public string User { get; set; }
        public string Role { get; set; }
        public string Type { get; set; }
        public string Level { get; set; }
    }
}
