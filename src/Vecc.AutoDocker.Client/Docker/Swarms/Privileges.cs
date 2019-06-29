namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class Privileges
    {
        public CredentialSpec CredentialSpec { get; set; }
        public SELinuxContext SELinuxContext { get; set; }
    }
}
