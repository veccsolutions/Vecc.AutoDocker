using System.Threading.Tasks;

namespace Vecc.AutoDocker.Client
{
    public interface IDockerTaskClient : IDockerClient
    {
        /// <summary>
        ///     List nodes
        /// </summary>
        /// <returns></returns>
        /// <seealso cref="https://docs.docker.com/engine/api/v1.39/#operation/NodeList"/>
        Task<Docker.Swarms.Task[]> GetTasksAsync();

        /// <summary>
        ///     List nodes matching the specified criteria
        /// </summary>
        /// <returns></returns>
        /// <seealso cref="https://docs.docker.com/engine/api/v1.39/#operation/NodeList"/>
        Task<Docker.Swarms.Task[]> GetTasksAsync(string desiredState, string id, string label, string name, string node, string service);

        /// <summary>
        ///     Inspect a node
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <seealso cref="https://docs.docker.com/engine/api/v1.39/#operation/NodeInspect"/>
        Task<Docker.Swarms.Task> GetTaskAsync(string id);
    }
}
