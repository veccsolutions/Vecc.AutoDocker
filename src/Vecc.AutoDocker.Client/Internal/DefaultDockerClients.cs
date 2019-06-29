namespace Vecc.AutoDocker.Client.Internal
{
    public class DefaultDockerClients : IDockerClients
    {
        public DefaultDockerClients(IDockerContainerClient containerClient,
                                    IDockerImagesClient imagesClient,
                                    IDockerNodeClient nodeClient,
                                    IDockerServiceClient serviceClient,
                                    IDockerSystemClient systemClient,
                                    IDockerTaskClient taskClient)
        {
            this.ContainerClient = containerClient;
            this.ImagesClient = imagesClient;
            this.NodeClient = nodeClient;
            this.ServiceClient = serviceClient;
            this.SystemClient = systemClient;
            this.TaskClient = taskClient;
        }

        public IDockerContainerClient ContainerClient { get; set; }
        public IDockerImagesClient ImagesClient { get; set; }
        public IDockerNodeClient NodeClient { get; set; }
        public IDockerServiceClient ServiceClient { get; set; }
        public IDockerSystemClient SystemClient { get; set; }
        public IDockerTaskClient TaskClient { get; set; }
    }
}
