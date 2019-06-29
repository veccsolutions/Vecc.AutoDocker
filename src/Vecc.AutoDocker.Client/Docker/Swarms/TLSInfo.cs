namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class TLSInfo
    {
        public string TrustRoot { get; set; }
        public byte[] CertIssuerSubject { get; set; }
        public byte[] CertIssuerPublicKey { get; set; }
    }
}
