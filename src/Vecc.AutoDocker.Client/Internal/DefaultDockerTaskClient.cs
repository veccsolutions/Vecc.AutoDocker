using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Vecc.AutoDocker.Client.Internal
{
    public class DefaultDockerTaskClient : DefaultDockerClient, IDockerTaskClient
    {
        private readonly ILogger<DefaultDockerTaskClient> _logger;

        public DefaultDockerTaskClient(HttpClient client, ILogger<DefaultDockerTaskClient> logger)
            : base(client)
        {
            this._logger = logger;
        }

        public Task<Docker.Swarms.Task[]> GetTasksAsync() => this.GetTasksAsync(null);

        public Task<Docker.Swarms.Task[]> GetTasksAsync(string desiredState, string id, string label, string name, string node, string service)
        {
            var filter = new Dictionary<string, string[]>();

            if (!string.IsNullOrWhiteSpace(desiredState))
            {
                filter["desired-state"] = new[] { desiredState };
            }
            if (!string.IsNullOrWhiteSpace(id))
            {
                filter["id"] = new[] { id };
            }
            if (!string.IsNullOrWhiteSpace(label))
            {
                filter["label"] = new[] { label };
            }
            if (!string.IsNullOrWhiteSpace(name))
            {
                filter["name"] = new[] { name };
            }
            if (!string.IsNullOrWhiteSpace(node))
            {
                filter["node"] = new[] { node };
            }
            if (!string.IsNullOrWhiteSpace(service))
            {
                filter["service"] = new[] { service };
            }

            return this.GetTasksAsync(filter);
        }

        public async Task<Docker.Swarms.Task[]> GetTasksAsync(Dictionary<string, string[]> filters)
        {
            var queryString = string.Empty;

            if (filters != null && filters.Count > 0)
            {
                var actualFilters = new Dictionary<string, Dictionary<string, bool>>();
                foreach (var filter in filters)
                {
                    var actualFilter = filter.Value.ToDictionary(x => x, _ => true);
                    actualFilters[filter.Key] = actualFilter;
                }
                var filterParameter = JsonConvert.SerializeObject(actualFilters);
                queryString = this.AddQueryParameter(queryString, "filters", filterParameter);
            }

            var uri = this.CombinePathAndQuery("/tasks", queryString);
            var response = await this.Client.GetAsync(uri);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<Docker.Swarms.Task[]>(this._logger);

            return result;
        }

        public async Task<Docker.Swarms.Task> GetTaskAsync(string id)
        {
            var uri = $"/tasks/" + HttpUtility.UrlEncode(id);
            var response = await this.Client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsAsync<Docker.Swarms.Task>(this._logger);
            return result;
        }
    }
}
