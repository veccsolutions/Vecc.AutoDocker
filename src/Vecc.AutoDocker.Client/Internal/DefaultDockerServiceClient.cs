using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Vecc.AutoDocker.Client.Docker.Swarms;

namespace Vecc.AutoDocker.Client.Internal
{
    public class DefaultDockerServiceClient : DefaultDockerClient, IDockerServiceClient
    {
        public DefaultDockerServiceClient(HttpClient client)
            : base(client)
        {
        }

        public async Task<Service[]> GetServicesAsync(string filters = "")
        {
            var queryString = string.Empty;

            if (!string.IsNullOrWhiteSpace(filters))
            {
                queryString = this.AddQueryParameter(queryString, "filters", filters);
            }

            var uri = this.CombinePathAndQuery("/services", queryString);
            var response = await this.Client.GetAsync(uri);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<Service[]>();

            return result;
        }

        public async Task<Service> GetServiceAsync(string id, bool insertDefaults = false)
        {
            var queryString = this.AddQueryParameter(string.Empty, "insertDefaults", insertDefaults);

            var uri = $"/services/" + HttpUtility.UrlEncode(id);
            uri = this.CombinePathAndQuery(uri, queryString);

            var response = await this.Client.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<Service>();

            return result;
        }
    }
}
