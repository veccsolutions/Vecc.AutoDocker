using System.Threading.Tasks;
using Vecc.AutoDocker.Client.Docker.Swarms;

namespace Vecc.AutoDocker.Client
{
    public interface IDockerNodeClient : IDockerClient
    {
        /// <summary>
        ///     List nodes
        /// </summary>
        /// <returns></returns>
        /// <seealso cref="https://docs.docker.com/engine/api/v1.39/#operation/NodeList"/>
        Task<Node[]> GetNodesAsync(string filters = "");

        /// <summary>
        ///     Inspect a node
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <seealso cref="https://docs.docker.com/engine/api/v1.39/#operation/NodeInspect"/>
        Task<Node> GetNodeAsync(string id);
    }
}
