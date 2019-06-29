using System;

namespace Vecc.AutoDocker.Client.Docker
{
    public class ContainerPathStat
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public int Mode { get; set; }
        public DateTime? MTime { get; set; }
        public string LinkTarget { get; set; }
    }
}
