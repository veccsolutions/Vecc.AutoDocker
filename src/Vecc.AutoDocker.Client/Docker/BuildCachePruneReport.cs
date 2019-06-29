namespace Vecc.AutoDocker.Client.Docker
{
    public class BuildCachePruneReport
    {
        public string[] CachesDeleted { get; set; }
        public long SpaceReclaimed { get; set; }
    }
}
