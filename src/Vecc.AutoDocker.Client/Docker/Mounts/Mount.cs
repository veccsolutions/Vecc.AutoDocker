namespace Vecc.AutoDocker.Client.Docker.Mounts
{
    public class Mount
    {
        public MountType Type { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public bool ReadOnly { get; set; }
        public Consistency Consistency { get; set; }
        public BindOptions BindOptions { get; set; }
        public VolumeOptions VolumeOptions { get; set; }
        public TmpfsOptions TmpfsOptions { get; set; }
    }
}
