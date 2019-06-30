using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Vecc.AutoDocker.Client;
using Vecc.AutoDocker.Client.Docker.Events;
using Vecc.AutoDocker.Config;
using Vecc.AutoDocker.Internal;

namespace Vecc.AutoDocker
{
    public class Monitor
    {
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly ILogger<Monitor> _logger;
        private readonly IOptionsMonitor<AutoDockerConfiguration> _options;
        private readonly IDockerSystemClient _dockerSystemClient;
        private readonly ConcurrentDictionary<Target, string> _previousTemplates;
        private readonly RazorRunner _razorRunner;

        public Monitor(ILogger<Monitor> logger, IOptionsMonitor<AutoDockerConfiguration> options, IDockerSystemClient dockerSystemClient, RazorRunner razorRunner)
        {
            this._cancellationTokenSource = new CancellationTokenSource();
            this._logger = logger;
            this._options = options;
            this._dockerSystemClient = dockerSystemClient;
            this._previousTemplates = new ConcurrentDictionary<Target, string>();
            this._razorRunner = razorRunner;
        }

        public async Task FirstRunAsync(IServiceProvider serviceProvider)
        {
            var dockerClients = serviceProvider.GetRequiredService<IDockerClients>();
            await this.OnEventOccurred(dockerClients, serviceProvider, null);
        }

        public Task MonitorAsync()
            => this._dockerSystemClient.MonitorEvents(null, null, this._cancellationTokenSource.Token, this.OnEventOccurred);

        public async Task OnEventOccurred(IDockerClients clients, IServiceProvider serviceProvider, Message message)
        {
            using (this._logger.BeginScope("{@event}", message))
            {
                this._logger.LogInformation("Event occurred");

                try
                {
                    var swarm = await this.GetSwarmInformationAsync(clients);
                    var tasks = new List<Task>();
                    var targets = this.FilterTargets(this._options.CurrentValue.Targets, message);

                    foreach (var target in this._options.CurrentValue.Targets)
                    {
                        tasks.Add(this.ProcessTarget(target, swarm));
                    }

                    await Task.WhenAll(tasks);
                }
                catch (Exception exception)
                {
                    this._logger.LogCritical(exception, "Unhandled exception while processing events! {@options}", this._options.CurrentValue);
                }
            }
        }

        private IEnumerable<Target> FilterTargets(Target[] targets, Message message)
        {
            foreach (var target in targets)
            {
                if ((string.IsNullOrWhiteSpace(target.WatchType) ||
                     target.WatchType.Equals(message.Type, StringComparison.InvariantCultureIgnoreCase)) &&
                    (target.WatchEvents == null ||
                     target.WatchEvents.Length == 0 ||
                     target.WatchEvents.Any(w => w.Equals(message.Action, StringComparison.InvariantCultureIgnoreCase))))
                {
                    yield return target;
                }
            }
        }

        private async Task<SwarmInformation> GetSwarmInformationAsync(IDockerClients clients)
        {
            var ping = await clients.SystemClient.PingAsync();
            var diskUsage = await clients.SystemClient.GetDiskUsageAsync();
            var version = await clients.SystemClient.GetSystemVersionAsync();
            var containers = await clients.ContainerClient.GetContainersAsync();
            var tasks = await clients.TaskClient.GetTasksAsync();
            var nodes = await clients.NodeClient.GetNodesAsync();
            var swarmServices = await clients.ServiceClient.GetServicesAsync();

            var swarm = new SwarmInformation
            {
                DiskUsage = diskUsage,
                LocalContainers = containers,
                Ping = ping,
                SwarmNodes = nodes,
                SwarmServices = swarmServices,
                SwarmTasks = tasks,
                SystemVersion = version
            };

            return swarm;
        }

        private async Task ProcessTarget(Target target, SwarmInformation swarm)
        {
            using (this._logger.BeginScope("{@target}", target))
            {
                try
                {
                    var text = Guid.NewGuid().ToString();
                    string oldTemplate = null;

                    if (!string.IsNullOrWhiteSpace(target.TemplateSource))
                    {
                        this._logger.LogTrace("Template source set, rendering template");
                        text = await this._razorRunner.Render(target.TemplateSource, swarm);
                        oldTemplate = this._previousTemplates.GetOrAdd(target, string.Empty);
                        this._logger.LogTrace("Resulting text: {text}", text);

                        if (oldTemplate != text)
                        {
                            this._logger.LogInformation("Rendered content changed, {@newContent}", text);

                            if (!string.IsNullOrWhiteSpace(target.Destination))
                            {
                                this._logger.LogInformation("Updating destination");
                                await File.WriteAllTextAsync(target.Destination, text);
                            }
                            else
                            {
                                this._logger.LogTrace("Destination file target blank, not writing");
                            }
                            this._previousTemplates[target] = text;
                        }
                        else
                        {
                            this._logger.LogInformation("Rendered content did not change");
                        }
                    }

                    if (oldTemplate != text &&
                        target.ExecuteOnChange != null &&
                        target.ExecuteOnChange.Length > 0)
                    {
                        this._logger.LogTrace("Execute on change has options, executing options.");
                        foreach (var execute in target.ExecuteOnChange)
                        {
                            this.Execute(execute);
                        }
                    }
                }
                catch (Exception exception)
                {
                    this._logger.LogError(exception, "Unable to process target");
                }
            }
        }

        private void Execute(ExecuteOnChange execute)
        {
            using (this._logger.BeginScope("@{execute}", execute))
            {
                this._logger.LogInformation("Executing");
                try
                {
                    var process = new Process();
                    if (!string.IsNullOrWhiteSpace(execute.Arguments))
                    {
                        process.StartInfo = new ProcessStartInfo(execute.Executable, execute.Arguments);
                    }
                    else
                    {
                        process.StartInfo = new ProcessStartInfo(execute.Executable);
                    }
                    process.Start();
                    process.WaitForExit();
                }
                catch (Exception exception)
                {
                    this._logger.LogError(exception, "Unable to execute");
                }
            }
        }

    }
}
