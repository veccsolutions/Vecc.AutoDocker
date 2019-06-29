using System;

namespace Vecc.AutoDocker.Client.Docker
{
    public class SystemVersion
    {
        public PlatformName Platform { get; set; }
        public ComponentVersion[] Components { get; set; }
        public Version Version { get; set; }
        public Version ApiVersion { get; set; }
        public Version MinApiVersion { get; set; }
        public string GitCommit { get; set; }
        public string GoVersion { get; set; }
        public string Os { get; set; }
        public string Arch { get; set; }
        public string KernelVersion { get; set; }
        public bool Experimental { get; set; }
        public DateTime BuildTime { get; set; }

        public class PlatformName
        {
            public string Name { get; set; }
        }
    }
}
