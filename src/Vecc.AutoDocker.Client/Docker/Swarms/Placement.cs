namespace Vecc.AutoDocker.Client.Docker.Swarms
{
    public class Placement
    {
        public string[] Constraints { get; set; }
        public PlacementPreference[] Preferences { get; set; }
        public long MaxReplicas { get; set; }
        public Platform[] Platforms { get; set; }
    }
}
