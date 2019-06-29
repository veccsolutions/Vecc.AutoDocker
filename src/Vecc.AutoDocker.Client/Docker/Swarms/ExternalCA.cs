namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class ExternalCA
    {
        public string Protocol { get; set; }
        public string URL { get; set; }
        public StringPairs Options { get; set; }
        public string CACert { get; set; }
    }
}
