namespace Vecc.AutoDocker.Client.Docker
{
    public class PushResult
    {
        public string Tag { get; set; }
        public string Digest { get; set; }
        public int Size { get; set; }
    }
}
