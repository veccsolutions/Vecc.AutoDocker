using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Logging;
using Vecc.AutoDocker.Client.Docker;

namespace Vecc.AutoDocker.Client.Internal
{
    public class DefaultDockerImagesClient : DefaultDockerClient, IDockerImagesClient
    {
        private readonly ILogger<DefaultDockerImagesClient> _logger;

        public DefaultDockerImagesClient(HttpClient client, ILogger<DefaultDockerImagesClient> logger)
            : base(client)
        {
            this._logger = logger;
        }

        public async Task<ImageInspect> GetImageAsync(string name)
        {
            var uri = $"/images/" + HttpUtility.UrlEncode(name) + "/json";
            var response = await this.Client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<ImageInspect>(this._logger);

            return result;
        }
    }
}
