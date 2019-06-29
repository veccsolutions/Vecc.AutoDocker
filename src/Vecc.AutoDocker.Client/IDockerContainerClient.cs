using System.Threading.Tasks;
using Vecc.AutoDocker.Client.Docker;

namespace Vecc.AutoDocker.Client
{
    public interface IDockerContainerClient : IDockerClient
    {

        // GET "/containers/json"
        Task<Container[]> GetContainersAsync(ContainerListOptions options = null);

        // POST "/containers/"+containerID+"/copy"
        Task CopyConfigAsync(string id, CopyConfig copy);

        // GET "/containers/{name:.*}/archive"
        Task<ContainerPathStat> GetContainerArchiveAsync(string id);

        /// <summary>
        /// Return low-level information about a container.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        /// <seealso cref="https://docs.docker.com/engine/api/v1.39/#operation/ContainerInspect"/>
        Task<ContainerJSON> GetContainerAsync(string id, bool size = false);

        // GET "/stats"
        Task GetStatsAsync();

        //POST "/containers/prune" -> ContainersPruneReport
        //POST "/volumes/prune" -> VolumesPruneReport
        //POST "/images/prune" -> ImagesPruneReport
        //POST "/build/prune"->BuildCachePruneReport
        // POST "/networks/prune"->NetworksPruneReport
    }
}
