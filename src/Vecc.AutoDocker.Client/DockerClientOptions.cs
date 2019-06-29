namespace Vecc.AutoDocker.Client
{
    public class DockerClientOptions
    {
        public string Host { get; set; }
        public string ClientCertificate { get; set; }
        public string ClientCertificatePassword { get; set; }
        public string ClientCertificatePasswordFilePath { get; set; }
    }
}
