namespace Vecc.AutoDocker.Client.Docker.Networks
{
    public class Task
    {
        public string Name { get; set; }
        public string EndpointId { get; set; }
        public string EndpointIP { get; set; }
        public StringPairs Info { get; set; }
    }
}
