using System.Collections.Generic;

namespace Vecc.AutoDocker.Client.Docker
{
    public class Info
    {
        public string ID { get; set; }
        public int Containers { get; set; }
        public int ContainersRunning { get; set; }
        public int ContainersPaused { get; set; }
        public int ContainersStopped { get; set; }
        public int Images { get; set; }
        public string Driver { get; set; }
        public string[][] DriverStatus { get; set; }
        public string[][] SystemStatus { get; set; }
        public PluginsInfo Plugins { get; set; }
        public bool MemoryLimit { get; set; }
        public bool SwapLimit { get; set; }
        public bool KernelMemory { get; set; }
        public bool KernelMemoryTCP { get; set; }
        public bool CpuCfsPeriod { get; set; }
        public bool CpuCfsQuota { get; set; }
        public bool CPUShares { get; set; }
        public bool CPUSet { get; set; }
        public bool PidsLimit { get; set; }
        public bool IPv4Forwarding { get; set; }
        public bool BridgeNfIptables { get; set; }
        public bool Debug { get; set; }
        public int NFd { get; set; }
        public bool OomKillDisable { get; set; }
        public int NGoroutines { get; set; }
        public string SystemTime { get; set; }
        public string LoggingDriver { get; set; }
        public string CgroupDriver { get; set; }
        public int NEventsListener { get; set; }
        public string KernelVersion { get; set; }
        public string OperatingSystem { get; set; }
        public string OSVersion { get; set; }
        public string OSType { get; set; }
        public string Architecture { get; set; }
        public string IndexServerAddress { get; set; }
        public Registries.ServiceConfig RegistryConfig { get; set; }
        public int NCPU { get; set; }
        public long MemTotal { get; set; }
        public Swarms.GenericResource GenericResources { get; set; }
        public string DockerRootDir { get; set; }
        public string HttpProxy { get; set; }
        public string HttpsProxy { get; set; }
        public string NoProxy { get; set; }
        public string Name { get; set; }
        public string[] Labels { get; set; }
        public bool ExperimentalBuild { get; set; }
        public string ServerVersion { get; set; }
        public string ClusterStore { get; set; }
        public string ClusterAdvertise { get; set; }
        public Dictionary<string, Runtime> Runtimes { get; set; }
        public Swarms.Info Swarm { get; set; }
        public bool LiveRestoreEnabled { get; set; }
        public Containers.Isolation Isolation { get; set; }
        public string InitBinary { get; set; }
        public Commit ContainerdCommit { get; set; }
        public Commit RuncCommit { get; set; }
        public Commit InitCommit { get; set; }
        public string[] SecurityOptions { get; set; }
        public string ProductLicense { get; set; }
        public string[] Warnings { get; set; }
    }
}
