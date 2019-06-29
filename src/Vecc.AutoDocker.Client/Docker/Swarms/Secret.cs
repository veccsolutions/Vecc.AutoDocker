namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class Secret : Meta
    {
        public string Id { get; set; }
        public SecretSpec Spec { get; set; }
    }
}
