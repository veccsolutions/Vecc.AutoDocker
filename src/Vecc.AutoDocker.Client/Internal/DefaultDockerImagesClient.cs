using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Vecc.AutoDocker.Client.Docker;

namespace Vecc.AutoDocker.Client.Internal
{
    public class DefaultDockerImagesClient : DefaultDockerClient, IDockerImagesClient
    {
        public DefaultDockerImagesClient(HttpClient client)
            : base(client)
        {
        }

        public async Task<ImageInspect> GetImageAsync(string name)
        {
            var uri = $"/images/" + HttpUtility.UrlEncode(name) + "/json";
            var response = await this.Client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<ImageInspect>();

            return result;
        }
    }
}
