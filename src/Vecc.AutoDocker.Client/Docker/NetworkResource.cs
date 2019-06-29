using System;
using System.Collections.Generic;

namespace Vecc.AutoDocker.Client.Docker
{
    public class NetworkResource
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public string Scope { get; set; }
        public string Driver { get; set; }
        public bool EnableIPv6 { get; set; }
        public Networks.IPAM IPAM { get; set; }
        public bool Internal { get; set; }
        public bool Attachable { get; set; }
        public bool Ingress { get; set; }
        public Networks.ConfigReference ConfigFrom { get; set; }
        public bool ConfigOnly { get; set; }
        public Dictionary<string, EndpointResource> Containers { get; set; }
        public StringPairs Options { get; set; }
        public StringPairs Labels { get; set; }
        public Networks.PeerInfo Peers { get; set; }
        public Dictionary<string, Networks.ServiceInfo> Services { get; set; }
    }
}
