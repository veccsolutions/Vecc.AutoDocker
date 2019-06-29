namespace Vecc.AutoDocker.Client.Docker.Containers
{
    public class RestartPolicy
    {
        public string Name { get; set; }
        public int MaximumRetryCount { get; set; }
    }
}
