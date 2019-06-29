using Newtonsoft.Json.Linq;

namespace Vecc.AutoDocker.Client.Docker
{
    public class ContainerStats
    {
        //TODO: What do we do for this?
        public JObject Body { get; set; }
        public string OSType { get; set; }
    }
}
