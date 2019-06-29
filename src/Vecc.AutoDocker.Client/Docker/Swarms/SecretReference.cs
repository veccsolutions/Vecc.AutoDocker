namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class SecretReference
    {
        public SecretReferenceFileTarget File { get; set; }
        public string SecretId { get; set; }
        public string SecretName { get; set; }
    }
}
