namespace Vecc.AutoDocker.Client.Docker.Networks
{
    public class ServiceInfo
    {
        public string VIP { get; set; }
        public string[] Ports { get; set; }
        public int LocalLBIndex { get; set; }
        public Task[] Tasks { get; set; }
    }
}
