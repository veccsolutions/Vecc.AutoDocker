namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class Spec : Annotations
    {
        public OrchestrationConfig Orchestration { get; set; }
        public RaftConfig Raft { get; set; }
        public DispatcherConfig Dispatcher { get; set; }
        public CAConfig CAConfig { get; set; }
        public TaskDefaults TaskDefaults { get; set; }
        public EncryptionConfig EncryptionConfig { get; set; }
    }
}
