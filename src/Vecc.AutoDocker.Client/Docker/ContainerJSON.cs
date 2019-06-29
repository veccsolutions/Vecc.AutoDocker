namespace Vecc.AutoDocker.Client.Docker
{
    public class ContainerJSON : ContainerJSONBase
    {
        public MountPoint[] Mounts { get; set; }
        public Containers.Config Config { get; set; }
        public NetworkSettings NetworkSettings { get; set; }
    }
}
