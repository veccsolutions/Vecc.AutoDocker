namespace Vecc.AutoDocker.Client.Docker.Units
{
    public class ULimit
    {
        public string Name { get; set; }
        public long Hard { get; set; }
        public long Soft { get; set; }
    }
}
