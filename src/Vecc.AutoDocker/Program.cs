using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Vecc.AutoDocker.Client;
using Vecc.AutoDocker.Internal;

namespace Vecc.AutoDocker
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            try
            {
                var services = ServiceProviderBuilder.BuildServiceProvider(args);
                var systemClient = services.GetRequiredService<IDockerSystemClient>();
                var cancellationTokenSource = new CancellationTokenSource();
                var logger = services.GetRequiredService<ILogger<Program>>();

                var events = systemClient.MonitorEvents(null, null, cancellationTokenSource.Token, async (clients, provider, message) =>
                {
                    var swarm = await GetSwarmInformationAsync(services);
                    var razorRunner = services.GetRequiredService<RazorRunner>();
                    var text = await razorRunner.Render("Templates/Dump.cshtml", swarm);
                    logger.LogInformation("Message Received: {@message}", message);
                    logger.LogInformation("Rendered message:\r\n{rendered}", text);
                });
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static async Task<SwarmInformation> GetSwarmInformationAsync(IServiceProvider services)
        {
            var dockerContainerClient = services.GetRequiredService<IDockerContainerClient>();
            var dockerSystemClient = services.GetRequiredService<IDockerSystemClient>();
            var dockerNodeClient = services.GetRequiredService<IDockerNodeClient>();
            var dockerServiceClient = services.GetRequiredService<IDockerServiceClient>();
            var dockerTaskClient = services.GetRequiredService<IDockerTaskClient>();
            var ping = await dockerSystemClient.PingAsync();
            var diskUsage = await dockerSystemClient.GetDiskUsageAsync();
            var version = await dockerSystemClient.GetSystemVersionAsync();
            var containers = await dockerContainerClient.GetContainersAsync();
            var tasks = await dockerTaskClient.GetTasksAsync();
            var nodes = await dockerNodeClient.GetNodesAsync();
            var swarmServices = await dockerServiceClient.GetServicesAsync();

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
    }
}
