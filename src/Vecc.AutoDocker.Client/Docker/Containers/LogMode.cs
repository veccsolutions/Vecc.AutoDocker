namespace Vecc.AutoDocker.Client.Docker.Containers
{
    //TODO: if this is used, we need to create a serializer for it
    // https://github.com/moby/moby/blob/52c16677b22d0aafc0e56db04e691164d46bb2c4/api/types/container/host_config.go#L325
    public enum LogMode
    {
        Default,
        Blocking,
        NonBlocking
    }
}
