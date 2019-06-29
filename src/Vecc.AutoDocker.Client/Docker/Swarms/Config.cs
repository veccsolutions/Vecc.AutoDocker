namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class Config : Meta
    {
        public string Id { get; set; }
        public ConfigSpec Spec { get; set; }
    }
}
