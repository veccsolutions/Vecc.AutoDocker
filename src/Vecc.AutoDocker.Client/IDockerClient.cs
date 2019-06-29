using System.Threading.Tasks;
using Vecc.AutoDocker.Client.Docker;

namespace Vecc.AutoDocker.Client
{
    public interface IDockerClient
    {
        Task<Ping> PingAsync();
    }
}
