using System;

namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class MetaAndAnnotations
    {
        public string Name { get; set; }
        public StringPairs Labels { get; set; }
        public SwarmVersion Version { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
