namespace Vecc.AutoDocker.Client.Docker
{
    public class Ping
    {
        public string APIVersion { get; set; }
        public string OSType { get; set; }
        public bool Experimental { get; set; }
        public string BuilderVersion { get; set; }
    }
}
