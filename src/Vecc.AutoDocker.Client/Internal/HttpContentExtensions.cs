using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Vecc.AutoDocker.Client.Internal
{
    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this HttpContent httpContent)
        {
            var content = await httpContent.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(content);

            return result;
        }
    }
}
