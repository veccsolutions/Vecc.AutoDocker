namespace Vecc.AutoDocker.Client.Docker.Containers
{
    public class DeviceMapping
    {
        public string PathOnHost { get; set; }
        public string PathInContainer { get; set; }
        public string CgroupPermissions { get; set; }
    }
}
