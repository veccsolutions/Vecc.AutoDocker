using System.Threading.Tasks;
using Vecc.AutoDocker.Client.Docker;

namespace Vecc.AutoDocker.Client
{
    public interface IDockerImagesClient : IDockerClient
    {
        Task<ImageInspect> GetImageAsync(string name);
    }
}
