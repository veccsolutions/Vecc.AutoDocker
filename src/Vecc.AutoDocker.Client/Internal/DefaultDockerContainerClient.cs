using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Vecc.AutoDocker.Client.Docker;

namespace Vecc.AutoDocker.Client.Internal
{
    public class DefaultDockerContainerClient : DefaultDockerClient, IDockerContainerClient
    {
        public DefaultDockerContainerClient(HttpClient client)
            : base(client)
        {
        }

        public async Task<Container[]> GetContainersAsync(ContainerListOptions options = null)
        {
            var queryString = string.Empty;

            if (options != null)
            {
                if (options.All)
                {
                    queryString = this.AddQueryParameter(queryString, "all", options.All);
                }
                if (options.Limit != 0)
                {
                    queryString = this.AddQueryParameter(queryString, "limit", options.Limit);
                }
                if (options.Size)
                {
                    queryString = this.AddQueryParameter(queryString, "size", options.Size);
                }
                var filters = options.Filters.ToString();
                if (!string.IsNullOrWhiteSpace(filters))
                {
                    queryString = this.AddQueryParameter(queryString, "filters", filters);
                }
            }

            var uri = this.CombinePathAndQuery("/containers/json", queryString);

            var response = await this.Client.GetAsync(uri);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<Container[]>();

            return result;
        }

        public async Task<ContainerJSON> GetContainerAsync(string id, bool size = false)
        {
            var uri = $"/containers/" + HttpUtility.UrlEncode(id) + "/json";
            var response = await this.Client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<ContainerJSON>();
            return result;
        }

        public Task CopyConfigAsync(string id, CopyConfig copy)
        {
            throw new NotImplementedException();
        }

        public Task<ContainerPathStat> GetContainerArchiveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task GetStatsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
