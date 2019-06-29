using Newtonsoft.Json;
using Vecc.AutoDocker.Client.JsonConverters;

namespace Vecc.AutoDocker.Client.Docker
{
    public class MountPoint
    {
        public Mounts.MountType Type { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Driver { get; set; }
        public string Mode { get; set; }
        public bool RW { get; set; }

        [JsonConverter(typeof(MountsPropagationConverter))]
        public Mounts.Propagation Propagation { get; set; }
    }
}
