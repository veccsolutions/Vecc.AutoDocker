namespace Vecc.AutoDocker.Client.Docker
{
    public class ImageInspect
    {
        public string Id { get; set; }
        public string[] RepoTags { get; set; }
        public string[] RepoDigests { get; set; }
        public string Parent { get; set; }
        public string Comment { get; set; }
        public string Created { get; set; }
        public string Container { get; set; }
        public Containers.Config ContainerConfig { get; set; }
        public string DockerVersion { get; set; }
        public string Author { get; set; }
        public Containers.Config Config { get; set; }
        public string Architecture { get; set; }
        public string Os { get; set; }
        public string OsVersion { get; set; }
        public long Size { get; set; }
        public long VirtualSize { get; set; }
        public GraphDriverData GraphDriverData { get; set; }
        public RootFS RootFS { get; set; }
        public ImageMetadata Metadata { get; set; }
    }
}
