using System;

namespace Vecc.AutoDocker.Client.Docker
{
    public class DiskUsage
    {
        public long LayersSize { get; set; }
        public ImageSummary[] Images { get; set; }
        public Container[] Containers { get; set; }
        public Volume[] Volumes { get; set; }
        public BuildCache[] BuildCache { get; set; }

        [Obsolete]
        public long BuilderSize { get; set; }
    }
}
