namespace Vecc.AutoDocker.Extensions
{
    public static class StringExtensions
    {
        public static string PadMax(this string value, int width, char padding = ' ')
        {
            if (value.Length > width)
            {
                return value.Substring(0, width);
            }

            return value.PadRight(width, padding);
        }
    }
}
