using System;
using System.Collections.Generic;

namespace Vecc.AutoDocker.Client.Docker
{
    public class NetworkSettings
    {
        public string Bridge { get; set; }
        public string SandboxId { get; set; }
        public bool HairpinMode { get; set; }
        public string LinkLocalIPv6Address { get; set; }
        public string LinkLocalIPv6PrefixLen { get; set; }
        public Nats.PortMap Ports { get; set; }
        public string SandboxKey { get; set; }
        public Networks.Address[] SecondaryIPAddresses { get; set; }
        public Networks.Address[] SecondaryIPv6Addresses { get; set; }

        [Obsolete]
        public string EndpointID { get; set; }
        [Obsolete]
        public string Gateway { get; set; }
        [Obsolete]
        public string GlobalIPv6Address { get; set; }
        [Obsolete]
        public string GlobalIPv6PrefixLen { get; set; }
        [Obsolete]
        public string IPAddress { get; set; }
        [Obsolete]
        public int IPPrefixLen { get; set; }
        [Obsolete]
        public string IPv6Gateway { get; set; }
        [Obsolete]
        public string MacAddress { get; set; }


        public Dictionary<string, Networks.EndpointSettings> Networks { get; set; }
    }
}
