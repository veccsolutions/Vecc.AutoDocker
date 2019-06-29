namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class RaftConfig
    {
        public long SnapshotInterval { get; set; }
        public long? KeepOldSnapshots { get; set; }
        public long LogEntriesForSlowFollowers { get; set; }
        public int ElectionTick { get; set; }
        public int HeartbeatTick { get; set; }
    }
}
