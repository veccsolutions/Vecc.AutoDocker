namespace Vecc.AutoDocker.Client.Docker
{
    public class ImagesPruneReport
    {
        public ImageDeleteResponseItem[] ImagesDeleted { get; set; }
        public long SpaceReclaimed { get; set; }
    }
}
