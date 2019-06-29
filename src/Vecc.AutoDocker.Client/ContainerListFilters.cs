using System.Collections.Generic;
using Newtonsoft.Json;

namespace Vecc.AutoDocker.Client
{
    /// <summary>
    /// https://docs.docker.com/engine/api/v1.39/#operation/ContainerList
    /// </summary>
    public class ContainerListFilters
    {
        public Filter<string> Ancestor { get; set; } = new Filter<string>();
        public Filter<string> Before { get; set; } = new Filter<string>();
        public Filter<string> Expose { get; set; } = new Filter<string>();
        public Filter<int> Exited { get; set; } = new Filter<int>();
        public Filter<string> Health { get; set; } = new Filter<string>();
        public Filter<string> Id { get; set; } = new Filter<string>();
        public Filter<string> Isolation { get; set; } = new Filter<string>();
        public Filter<bool> IsTask { get; set; } = new Filter<bool>();
        public Filter<string> Label { get; set; } = new Filter<string>();
        public Filter<string> Name { get; set; } = new Filter<string>();
        public Filter<string> Network { get; set; } = new Filter<string>();
        public Filter<string> Publish { get; set; } = new Filter<string>();
        public Filter<string> Since { get; set; } = new Filter<string>();
        public Filter<string> Status { get; set; } = new Filter<string>();
        public Filter<string> Volume { get; set; } = new Filter<string>();

        public override string ToString()
        {
            var dictionary = new Dictionary<string, Dictionary<string, bool>>();

            this.AddIfSet(dictionary, "ancestor", this.Ancestor);
            this.AddIfSet(dictionary, "before", this.Before);
            this.AddIfSet(dictionary, "expose", this.Expose);
            this.AddIfSet(dictionary, "exited", this.Exited);
            this.AddIfSet(dictionary, "health", this.Health);
            this.AddIfSet(dictionary, "id", this.Id);
            this.AddIfSet(dictionary, "isolation", this.Isolation);
            this.AddIfSet(dictionary, "is-task", this.IsTask);
            this.AddIfSet(dictionary, "label", this.Label);
            this.AddIfSet(dictionary, "name", this.Name);
            this.AddIfSet(dictionary, "network", this.Network);
            this.AddIfSet(dictionary, "publish", this.Publish);
            this.AddIfSet(dictionary, "since", this.Since);
            this.AddIfSet(dictionary, "status", this.Status);
            this.AddIfSet(dictionary, "volume", this.Volume);

            if (dictionary.Count == 0)
            {
                return null;
            }

            var result = JsonConvert.SerializeObject(dictionary);
            return result;
        }

        private void AddIfSet<T>(Dictionary<string, Dictionary<string, bool>> dictionary, string name, Filter<T> filter)
        {
            if (filter.IsSet)
            {
                string value = (string)filter;

                if (typeof(T) == typeof(bool))
                {
                    value = value.ToLower();
                }

                dictionary[name] = new Dictionary<string, bool>() { { value, true } };
            }
        }
    }
}
