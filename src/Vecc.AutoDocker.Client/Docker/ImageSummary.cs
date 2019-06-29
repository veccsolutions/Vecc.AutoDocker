namespace Vecc.AutoDocker.Client.Docker
{
    public class ImageSummary
    {
        public long Containers { get; set; }
        public long Created { get; set; }
        public string Id { get; set; }
        public StringPairs Labels { get; set; }
        public string ParentId { get; set; }
        public string[] RepoDigests { get; set; }
        public string[] RepoTags { get; set; }
        public long SharedSize { get; set; }
        public long Size { get; set; }
        public long VirtualSize { get; set; }
    }
}
