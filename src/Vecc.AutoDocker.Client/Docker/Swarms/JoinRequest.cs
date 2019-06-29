namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class JoinRequest
    {
        public string ListenAddr { get; set; }
        public string AdvertiseAddr { get; set; }
        public string DataPathAddr { get; set; }
        public string[] RemoteAddrs { get; set; }
        public string JoinToken { get; set; }
        public NodeAvailability Availability { get; set; }
    }
}
