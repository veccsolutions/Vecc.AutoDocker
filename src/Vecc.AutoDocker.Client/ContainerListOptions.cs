namespace Vecc.AutoDocker.Client
{
    public class ContainerListOptions
    {
        public bool All { get; set; } = false;
        public int Limit { get; set; } = 0;
        public bool Size { get; set; } = false;
        public ContainerListFilters Filters { get; } = new ContainerListFilters();
    }
}
