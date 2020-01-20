using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Vecc.AutoDocker.Client.Docker;
using Vecc.AutoDocker.Client.Docker.Events;

namespace Vecc.AutoDocker.Client.Internal
{
    public class DefaultDockerSystemClient : DefaultDockerClient, IDockerSystemClient
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<DefaultDockerServiceClient> _logger;

        public DefaultDockerSystemClient(HttpClient client, IServiceProvider serviceProvider, ILogger<DefaultDockerServiceClient> logger)
            : base(client)
        {
            this._serviceProvider = serviceProvider;
            this._logger = logger;
        }

        public async Task<DiskUsage> GetDiskUsageAsync()
        {
            var response = await this.Client.GetAsync("/system/df");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<DiskUsage>(this._logger);

            return result;
        }

        public async Task<Info> GetInfoAsync()
        {
            var response = await this.Client.GetAsync("/info");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<Info>(this._logger);

            return result;
        }

        public async Task<SystemVersion> GetSystemVersionAsync()
        {
            var response = await this.Client.GetAsync("/version");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<SystemVersion>(this._logger);

            return result;
        }

        public async Task MonitorEvents(DateTime? since, DateTime? until, CancellationToken cancellationToken, Func<IDockerClients, IServiceProvider, Message, Task> callback)
        {
            var queryString = string.Empty;

            if (since.HasValue)
            {
                queryString = this.AddQueryParameter(queryString, "since", since.Value);
            }

            if (until.HasValue)
            {
                queryString = this.AddQueryParameter(queryString, "until", until.Value);
            }

            var uri = this.CombinePathAndQuery("/events", queryString);

            var response = await this.Client.GetStreamAsync(uri);
            var messageContent = string.Empty;
            while (response.CanRead && !cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var buffer = new byte[8192];
                    var bytesRead = await response.ReadAsync(buffer, 0, 8192);
                    messageContent += Encoding.Default.GetString(buffer, 0, bytesRead);

                    if (bytesRead == 8192)
                    {
                        continue;
                    }
                    else
                    {
                        using (var reader = new StringReader(messageContent))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                this._logger.LogTrace("Received Content: {@content}", line);
                                var message = JsonConvert.DeserializeObject<Message>(line);
                                var services = (IDockerClients)this._serviceProvider.GetService(typeof(IDockerClients));

                                await callback(services, this._serviceProvider, message);
                            }
                        }
                        messageContent = string.Empty;
                    }
                }
                catch (Exception exception)
                {
                    this._logger.LogError(exception, "Unexpected exception while following event stream");
                }
            }
        }
    }
}
