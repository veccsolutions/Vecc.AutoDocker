using System;

namespace Vecc.AutoDocker.Client.Docker
{
    public class BuildCache
    {
        public string Id { get; set; }
        public string Parent { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public long Size { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUsedAt { get; set; }
        public int UsageCount { get; set; }
    }
}
