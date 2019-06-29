namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class Service : Meta
    {
        public string Id { get; set; }
        public ServiceSpec Spec { get; set; }
        public ServiceSpec PreviousSpec { get; set; }
        public Endpoint Endpoint { get; set; }
        public UpdateStatus UpdateStatus { get; set; }
    }
}
