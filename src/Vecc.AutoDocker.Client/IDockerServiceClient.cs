using System.Threading.Tasks;
using Vecc.AutoDocker.Client.Docker.Swarms;

namespace Vecc.AutoDocker.Client
{
    public interface IDockerServiceClient : IDockerClient
    {
        Task<Service[]> GetServicesAsync(string filters = "");
        Task<Service> GetServiceAsync(string id, bool insertDefaults = false);
    }
}
