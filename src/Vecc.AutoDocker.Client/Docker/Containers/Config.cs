using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Vecc.AutoDocker.Client.Docker.Containers
{
    public class Config
    {
        public string Hostname { get; set; }
        public string DomainName { get; set; }
        public string User { get; set; }
        public bool AttachStdin { get; set; }
        public bool AttachStdout { get; set; }
        public bool AttachStderr { get; set; }
        public Nats.PortSet ExposedPorts { get; set; }
        public bool Tty { get; set; }
        public bool OpenStdin { get; set; }
        public bool StdinOnce { get; set; }
        public string[] Env { get; set; }
        public string[] Cmd { get; set; }
        public HealthConfig HealthCheck { get; set; }
        public bool? ArgsEscaped { get; set; }
        public string Image { get; set; }
        public Dictionary<string, JObject> Volumes { get; set; } //TODO: research this
        public string WorkingDir { get; set; }
        public string[] Entrypoint { get; set; }
        public bool NetworkDisabled { get; set; }
        public string MacAddress { get; set; }
        public string[] OnBuild { get; set; }
        public StringPairs Labels { get; set; }
        public string StopSignal { get; set; }
        public int? StopTimeout { get; set; }
        public string[] Shell { get; set; }
    }
}
