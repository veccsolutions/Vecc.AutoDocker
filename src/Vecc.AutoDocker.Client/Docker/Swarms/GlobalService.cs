namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    //TODO: Create a serializer:
    // https://github.com/moby/moby/blob/52c16677b22d0aafc0e56db04e691164d46bb2c4/api/types/swarm/service.go#L71
    public enum GlobalService
    {
        Pause,
        Continue,
        Rollback,
        StopFirst,
        StartAt
    }
}
