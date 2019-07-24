using System;
using System.Linq;
using Vecc.AutoDocker.Client.Docker;
using Vecc.AutoDocker.Client.Docker.Swarms;
using Vecc.AutoDocker.Extensions;

namespace Vecc.AutoDocker
{
    public class SwarmInformation
    {
        public Ping Ping { get; set; }
        public DiskUsage DiskUsage { get; set; }
        public SystemVersion SystemVersion { get; set; }
        public Container[] LocalContainers { get; set; }
        public Task[] SwarmTasks { get; set; }
        public Node[] SwarmNodes { get; set; }
        public Service[] SwarmServices { get; set; }

        public Service[] GetServicesWithLabel(string label, string value) =>
            this.SwarmServices?.Where(service => service.Spec.HasMatchingLabelValue(label, value)).ToArray();
        public Service GetServiceForTask(Task task) => this.SwarmServices?.FirstOrDefault(service => service.Id.Equals(task.ServiceId, StringComparison.InvariantCultureIgnoreCase));
        public Node GetNodeForTask(Task task) => this.SwarmNodes?.FirstOrDefault(node => node.Id.Equals(task.NodeId, StringComparison.InvariantCultureIgnoreCase));
    }
}
