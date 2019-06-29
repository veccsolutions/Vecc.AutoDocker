using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Vecc.AutoDocker.Client.Docker.Registries
{
    public class ServiceConfig
    {
        public JObject AllowNondistributableArtifactsCIDRs { get; set; }
        public string[] AllowNondistributableArtifactsHostnames { get; set; }
        public JObject InsecureRegistryCIDRs { get; set; }
        public Dictionary<string, IndexInfo> IndexConfigs { get; set; }
        public string[] Mirrors { get; set; }
    }
}
