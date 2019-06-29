namespace Vecc.AutoDocker.Client.Docker
{
    public class ContainersPruneReport
    {
        public string[] ContainersDeleted { get; set; }
        public long SpaceReclaimed { get; set; }
    }
}
