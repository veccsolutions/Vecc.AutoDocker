using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Vecc.AutoDocker.Client.Docker.Swarms;

namespace Vecc.AutoDocker.Client.Internal
{
    public class DefaultDockerNodeClient : DefaultDockerClient, IDockerNodeClient
    {
        public DefaultDockerNodeClient(HttpClient client)
            : base(client)
        {
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

            var result = await response.Content.ReadAsAsync<Node[]>();

            return result;
        }

        public async Task<Node> GetNodeAsync(string id)
        {
            var uri = $"/nodes/" + HttpUtility.UrlEncode(id);
            var response = await this.Client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<Node>();
            return result;
        }
    }
}
