using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Vecc.AutoDocker
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var services = ServiceProviderBuilder.BuildServiceProvider(args);
            var monitor = services.GetRequiredService<Monitor>();
            await monitor.FirstRunAsync(services);
            var logger = services.GetRequiredService<ILogger<Program>>();

            while (true)
            {
                try
                {
                    await monitor.MonitorAsync();
                }
                catch (Exception e)
                {
                    logger.LogCritical(e, "Unexpected error while monitoring the docker socker socket");
                }
            }
        }
    }
}
