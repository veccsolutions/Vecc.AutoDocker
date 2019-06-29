using Newtonsoft.Json;
using Vecc.AutoDocker.Client.JsonConverters;

namespace Vecc.AutoDocker.Client.Docker.Mounts
{
    public class BindOptions
    {
        [JsonConverter(typeof(MountsPropagationConverter))]
        public Propagation Propagation { get; set; }
        public bool NonRecursive { get; set; }
    }
}
