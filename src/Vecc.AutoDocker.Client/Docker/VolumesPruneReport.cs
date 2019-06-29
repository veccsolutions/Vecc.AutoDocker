namespace Vecc.AutoDocker.Client.Docker
{
    public class VolumesPruneReport
    {
        public string[] VolumesDeleted { get; set; }
        public long SpaceReclaimed { get; set; }
    }
}
