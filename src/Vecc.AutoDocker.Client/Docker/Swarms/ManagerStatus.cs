namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class ManagerStatus
    {
        public bool Leader { get; set; }
        public Reachability Reachability { get; set; }
        public string Addr { get; set; }
    }
}
