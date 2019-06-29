namespace Vecc.AutoDocker.Client.Docker.Containers
{
    public class Resources
    {
        public long CpuShares { get; set; }
        public long Memory { get; set; }
        public long NanoCpus { get; set; }
        public string CgroupParent { get; set; }
        public short BlkioWeight { get; set; }
        public BlkIODevs.WeightDevice[] BlkioWeightDevice { get; set; }
        public BlkIODevs.ThrottleDevice[] BlkioDeviceReadBps { get; set; }
        public BlkIODevs.ThrottleDevice[] BlkioDeviceWriteBps { get; set; }
        public BlkIODevs.ThrottleDevice[] BlkioDeviceReadIOps { get; set; }
        public BlkIODevs.ThrottleDevice[] BlkioDeviceWriteIOps { get; set; }
        public long CpuPeriod { get; set; }
        public long CpuQuota { get; set; }
        public long CpuRealtimePeriod { get; set; }
        public long CpuRealtimeRuntime { get; set; }
        public string CpusetCpus { get; set; }
        public string CpusetMems { get; set; }
        public DeviceMapping[] Devices { get; set; }
        public string[] DeviceCgroupRules { get; set; }
        public DeviceRequest[] DeviceRequests { get; set; }
        public long KernelMemory { get; set; }
        public long KernelMemoryTCP { get; set; }
        public long MemorySwap { get; set; }
        public long? MemorySwappiness { get; set; }
        public bool? OomKillDisable { get; set; }
        public long? PidsLimit { get; set; }
        public Units.ULimit[] ULimits { get; set; }

        public long CpuCount { get; set; }
        public long CpuPercent { get; set; }
        public long IOMaximumIOps { get; set; }
        public long IOMaximumBandwidth { get; set; }
    }
}
