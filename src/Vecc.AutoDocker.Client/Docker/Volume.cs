using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Vecc.AutoDocker.Client.Docker
{
    public class Volume
    {
        public string CreatedAt { get; set; }
        public string Driver { get; set; }
        public StringPairs Labels { get; set; }
        public string Mountpoint { get; set; }
        public string Name { get; set; }
        public StringPairs Options { get; set; }
        public string Scope { get; set; }
        public Dictionary<string, JObject> Status { get; set; }
        public VolumeUsageData UsageData { get; set; }
    }
}
