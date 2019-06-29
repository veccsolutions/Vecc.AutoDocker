namespace Vecc.AutoDocker.Client.Docker
{
    public class Port
    {
        public string IP { get; set; }
        public short PrivatePort { get; set; }
        public short PublicPort { get; set; }
        public string Type { get; set; }
    }
}
