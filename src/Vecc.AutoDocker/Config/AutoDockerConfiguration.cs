using Vecc.AutoDocker.Client;

namespace Vecc.AutoDocker.Config
{
    public class AutoDockerConfiguration
    {
        public Target[] Targets { get; set; }
        public DockerClientOptions Client { get; set; }
    }
}
