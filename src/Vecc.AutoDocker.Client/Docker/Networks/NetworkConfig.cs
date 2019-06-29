using System.Collections.Generic;

namespace Vecc.AutoDocker.Client.Docker.Networks
{
    public class NetworkConfig
    {
        public Dictionary<string, EndpointSettings> EndpointsConfig { get; set; }
    }
}
