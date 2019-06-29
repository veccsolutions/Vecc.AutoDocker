using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Vecc.AutoDocker.Client.Docker;

namespace Vecc.AutoDocker.Client.Internal
{
    public class DefaultDockerClient : IDockerClient
    {
        protected readonly HttpClient Client;

        public DefaultDockerClient(HttpClient client)
        {
            this.Client = client;
        }

        public async Task<Ping> PingAsync()
        {
            var response = await this.Client.GetAsync("/_ping");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            if (content != "OK")
            {
                throw new Exception("Docker ping result invalid. Expected OK, received: " + (content ?? "<NULL>"));
            }

            var result = new Ping();

            result.APIVersion = this.GetValueFromHeader(response.Headers, "API-Version");
            result.Experimental = bool.Parse(this.GetValueFromHeader(response.Headers, "Docker-Experimental"));
            result.OSType = this.GetValueFromHeader(response.Headers, "OSType"); response.Headers.GetValues("OSType");
            return result;
        }

        protected string AddQueryParameter(string current, string key, string value)
        {
            var slug = $"{HttpUtility.UrlEncode(key)}={HttpUtility.UrlEncode(value)}";
            if (string.IsNullOrWhiteSpace(current))
            {
                current = slug;
            }
            else
            {
                current += $"&{slug}";
            }
            return current;
        }

        protected string AddQueryParameter(string current, string key, object value)
            => this.AddQueryParameter(current, key, value.ToString());

        protected string CombinePathAndQuery(string path, string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return path;
            }

            return $"{path}?{query}";
        }

        protected string GetValueFromHeader(HttpResponseHeaders headers, string name)
        {
            if (headers.TryGetValues(name, out var values))
            {
                return values?.FirstOrDefault();
            }

            return null;
        }
    }
}
