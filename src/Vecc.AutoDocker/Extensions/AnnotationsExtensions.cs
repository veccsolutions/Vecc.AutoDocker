using System;
using System.Linq;
using Vecc.AutoDocker.Client.Docker.Swarms;

namespace Vecc.AutoDocker.Extensions
{
    public static class AnnotationsExtensions
    {
        public static string GetLabelValue(this Annotations annotation, string name)
        {
            var result = annotation?.Labels?.FirstOrDefault(x => x.Key.Equals(name, StringComparison.InvariantCultureIgnoreCase)).Value;

            return result;
        }

        public static bool HasMatchingLabelValue(this Annotations annotation, string name, string value)
        {
            var result = annotation?.Labels?.Any(x => x.Key.Equals(name, StringComparison.InvariantCultureIgnoreCase) &&
                                                      x.Value.Equals(value, StringComparison.InvariantCultureIgnoreCase));

            return result ?? false;
        }

        public static bool LabelIsEnabled(this Annotations annotation, string name)
            => HasMatchingLabelValue(annotation, name, "true");
    }
}
