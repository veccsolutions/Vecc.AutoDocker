namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class IPAMOptions
    {
        public Driver Driver { get; set; }
        public IPAMConfig[] Configs { get; set; }
    }
}
