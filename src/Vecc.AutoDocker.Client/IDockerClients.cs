namespace Vecc.AutoDocker.Client
{
    public interface IDockerClients
    {
        IDockerContainerClient ContainerClient { get; set; }
        IDockerImagesClient ImagesClient { get; set; }
        IDockerNodeClient NodeClient { get; set; }
        IDockerServiceClient ServiceClient { get; set; }
        IDockerSystemClient SystemClient { get; set; }
        IDockerTaskClient TaskClient { get; set; }

    }
}
