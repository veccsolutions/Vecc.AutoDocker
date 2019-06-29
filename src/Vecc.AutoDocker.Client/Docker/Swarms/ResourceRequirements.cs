namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class ResourceRequirements
    {
        public Resources Limits { get; set; }
        public Resources Reservations { get; set; }
    }
}
