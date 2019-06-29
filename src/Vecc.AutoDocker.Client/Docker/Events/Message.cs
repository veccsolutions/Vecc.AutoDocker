namespace Vecc.AutoDocker.Client.Docker.Events
{
    public class Message
    {
        public string Status { get; set; }
        public string Id { get; set; }
        public string From { get; set; }
        public string Type { get; set; }
        public string Action { get; set; }
        public Actor Actor { get; set; }
        public string Scope { get; set; }
        public long Time { get; set; }
        public long TimeNano { get; set; }
    }
}
