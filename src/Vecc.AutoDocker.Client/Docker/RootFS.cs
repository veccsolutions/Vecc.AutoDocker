namespace Vecc.AutoDocker.Client.Docker
{
    public class RootFS
    {
        public string Type { get; set; }
        public string[] Layers { get; set; }
        public string BaseLayer { get; set; }
    }
}
