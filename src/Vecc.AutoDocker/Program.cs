using System;
using Microsoft.Extensions.DependencyInjection;

namespace Vecc.AutoDocker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var services = ServiceProviderBuilder.BuildServiceProvider(args);
                var monitor = services.GetRequiredService<Monitor>();
                var monitorTask = monitor.MonitorAsync();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
