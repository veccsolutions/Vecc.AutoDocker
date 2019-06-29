namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class Task : MetaAndAnnotations
    {
        public string Id { get; set; }
        public TaskSpec Spec { get; set; }
        public string ServiceId { get; set; }
        public int? Slot { get; set; }
        public string NodeId { get; set; }
        public TaskStatus Status { get; set; }
        public TaskState DesiredState { get; set; }
        public NetworkAttachment[] NetworksAttachments { get; set; }
        public GenericResource[] GenericResources { get; set; }
    }
}
