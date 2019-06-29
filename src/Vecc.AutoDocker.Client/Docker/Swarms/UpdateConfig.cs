namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class UpdateConfig
    {
        public long Parallelism { get; set; }
        public long Delay { get; set; }
        public string FailureAction { get; set; }
        public long Monitor { get; set; }
        public float MaxFailureRatio { get; set; }
        public string Order { get; set; }
    }
}
