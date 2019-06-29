namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class RestartPolicy
    {
        //TODO: this needs a json converter:
        //https://github.com/moby/moby/blob/52c16677b22d0aafc0e56db04e691164d46bb2c4/api/types/swarm/task.go#L162
        public RestartPolicyCondition Condition { get; set; }
        public long? Delay { get; set; }
        public long? MaxAttempts { get; set; }
        public long? Window { get; set; }
    }
}
