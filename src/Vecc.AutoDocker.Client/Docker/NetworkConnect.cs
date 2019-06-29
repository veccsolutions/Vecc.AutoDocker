namespace Vecc.AutoDocker.Client.Docker
{
    public class NetworkConnect
    {
        public string Container { get; set; }
        public Networks.EndpointSettings EndpointConfig { get; set; }
    }
}
