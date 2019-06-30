using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.ObjectPool;
using Microsoft.Extensions.Options;
using Serilog;
using Vecc.AutoDocker.Client;
using Vecc.AutoDocker.Client.Internal;
using Vecc.AutoDocker.Config;
using Vecc.AutoDocker.Internal;

namespace Vecc.AutoDocker
{
    public static class ServiceProviderBuilder
    {
        public static IServiceProvider BuildServiceProvider(string[] args)
        {
            var services = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables()
                .AddUserSecrets(typeof(Program).Assembly)
                .AddCommandLine(args)
                .Build();

            services.Configure<DockerClientOptions>(configuration.GetSection(typeof(DockerClientOptions).FullName));
            services.Configure<AutoDockerConfiguration>(configuration.GetSection(typeof(AutoDockerConfiguration).FullName));

            services.AddLogging(builder =>
            {
                var serilogBuilder = new LoggerConfiguration()
                    .WriteTo.Console(new Serilog.Formatting.Json.JsonFormatter(renderMessage: true));
                var logger = serilogBuilder.CreateLogger();

                builder.AddSerilog(logger);
            });

            services.AddDockerServiceClient<IDockerContainerClient, DefaultDockerContainerClient>();
            services.AddDockerServiceClient<IDockerImagesClient, DefaultDockerImagesClient>();
            services.AddDockerServiceClient<IDockerNodeClient, DefaultDockerNodeClient>();
            services.AddDockerServiceClient<IDockerServiceClient, DefaultDockerServiceClient>();
            services.AddDockerServiceClient<IDockerSystemClient, DefaultDockerSystemClient>();
            services.AddDockerServiceClient<IDockerTaskClient, DefaultDockerTaskClient>();

            services.AddSingleton<RazorRunner>();
            services.AddSingleton<Monitor>();
            services.AddTransient<IDockerClients, DefaultDockerClients>();

            services.AddRazor(configuration);


            return services.BuildServiceProvider();
        }

        private static string GetContentOrValue(string path, string value)
        {
            if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
            {
                return File.ReadAllText(path);
            }

            return value;
        }

        private static void AddDockerServiceClient<TInterface, TImplementation>(this IServiceCollection services)
            where TInterface : class, IDockerClient
            where TImplementation : class, TInterface
            => services.AddHttpClient<TInterface, TImplementation>()
                       .ConfigurePrimaryHttpMessageHandler(ConfigureDockerClientMessageHandler)
                       .ConfigureHttpClient(ConfigureDockerHttpClient);

        private static HttpClientHandler ConfigureDockerClientMessageHandler(IServiceProvider serviceProvider)
        {
            var httpClientHandler = new HttpClientHandler();
            var options = serviceProvider.GetRequiredService<IOptions<DockerClientOptions>>();
            var password = GetContentOrValue(options.Value.ClientCertificatePasswordFilePath, options.Value.ClientCertificatePassword);

            var clientCertificate = new X509Certificate2(options.Value.ClientCertificate, password, X509KeyStorageFlags.Exportable);
            httpClientHandler.ClientCertificates.Add(clientCertificate);
            httpClientHandler.CheckCertificateRevocationList = false;
            httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            return httpClientHandler;
        }

        private static void ConfigureDockerHttpClient(IServiceProvider serviceProvider, HttpClient client)
        {
            var options = serviceProvider.GetRequiredService<IOptions<DockerClientOptions>>();
            client.BaseAddress = new Uri(options.Value.Host);
        }

        private static IServiceCollection AddRazor(this IServiceCollection services, IConfiguration configuration)
        {
            var hostingEnvironment = new HostingEnvironment
            {
                ApplicationName = Assembly.GetEntryAssembly()?.GetName().Name
            };

            services.AddSingleton<IHostingEnvironment>(hostingEnvironment);
            services.AddSingleton<DiagnosticSource>((IServiceProvider serviceProvider) => new DiagnosticListener("DummySource"));
            services.AddTransient<ObjectPoolProvider, DefaultObjectPoolProvider>();

            services.AddMvcCore()
                    .AddRazorViewEngine(options =>
                    {
                        options.AllowRecompilingViewsOnFileChange = true;
                        options.FileProviders.Clear();
                        options.FileProviders.Add(GetPhysicalFileProvider(configuration));
                    });

            return services;
        }

        private static IFileProvider GetPhysicalFileProvider(IConfiguration configuration)
        {
            var options = configuration.GetSection(typeof(AutoDockerConfiguration).FullName).Get<AutoDockerConfiguration>();
            var root = options.TemplateRootPath;

            if (string.IsNullOrWhiteSpace(root))
            {
                var libraryPath = typeof(Program).Assembly.Location;
                var library = new FileInfo(libraryPath);
                root = library.DirectoryName;
            }

            var result = new PhysicalFileProvider(root);

            return result;
        }
    }
}
