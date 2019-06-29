namespace Vecc.AutoDocker.Client.Docker
{
    public class ContainerNode
    {
        public string ID { get; set; }
        public string IP { get; set; }
        public string Addr { get; set; }
        public string Name { get; set; }
        public int Cpus { get; set; }
        public long Memory { get; set; }
        public StringPairs Labels { get; set; }
    }
}
