using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Vecc.AutoDocker.Client.Internal
{
    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this HttpContent httpContent, ILogger logger)
        {
            var content = await httpContent.ReadAsStringAsync();

            try
            {
                logger?.LogTrace("Content to deserialize: {@content}", content);
                var result = JsonConvert.DeserializeObject<T>(content);

                return result;
            }
            catch (Exception exception)
            {
                logger?.LogError(exception, "Unable to deserialize content: {@content}", content);
                throw;
            }
        }
    }
}
