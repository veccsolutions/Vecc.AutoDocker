using System;
using System.Threading;
using System.Threading.Tasks;
using Vecc.AutoDocker.Client.Docker;
using Vecc.AutoDocker.Client.Docker.Events;

namespace Vecc.AutoDocker.Client
{
    public interface IDockerSystemClient : IDockerClient
    {
        // GET "/version"
        Task<SystemVersion> GetSystemVersionAsync();

        // GET "/system/df" -> DiskUsage
        Task<DiskUsage> GetDiskUsageAsync();

        // GET "/info"
        Task<Info> GetInfoAsync();

        Task MonitorEvents(DateTime? since, DateTime? until, CancellationToken cancellationToken, Func<IDockerClients, IServiceProvider, Message, Task> callback);
    }
}
