using System.Collections.Generic;

namespace Vecc.AutoDocker.Client.Docker
{
    public class SummaryNetworkSettings
    {
        public Dictionary<string, Networks.EndpointSettings> Networks { get; set; }
    }
}
