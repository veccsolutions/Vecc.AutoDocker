namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class CAConfig
    {
        public long NodeCertExpiry { get; set; }
        public ExternalCA[] ExternalCAs { get; set; }
        public string SigningCACert { get; set; }
        public string SigningCAKey { get; set; }
        public long? ForceRotate { get; set; }
    }
}
