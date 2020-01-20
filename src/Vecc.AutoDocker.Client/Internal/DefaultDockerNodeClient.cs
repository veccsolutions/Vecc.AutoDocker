using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Logging;
using Vecc.AutoDocker.Client.Docker.Swarms;

namespace Vecc.AutoDocker.Client.Internal
{
    public class DefaultDockerNodeClient : DefaultDockerClient, IDockerNodeClient
    {
        private readonly ILogger<DefaultDockerNodeClient> _logger;

        public DefaultDockerNodeClient(HttpClient client, ILogger<DefaultDockerNodeClient> logger)
            : base(client)
        {
            this._logger = logger;
        }

        public async Task<Node[]> GetNodesAsync(string filters = "")
        {
            var queryString = string.Empty;

            if (!string.IsNullOrWhiteSpace(filters))
            {
                queryString = this.AddQueryParameter(queryString, "filters", filters);
            }

            var uri = this.CombinePathAndQuery("/nodes", queryString);
            var response = await this.Client.GetAsync(uri);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<Node[]>(this._logger);

            return result;
        }

        public async Task<Node> GetNodeAsync(string id)
        {
            var uri = $"/nodes/" + HttpUtility.UrlEncode(id);
            var response = await this.Client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<Node>(this._logger);
            return result;
        }
    }
}
