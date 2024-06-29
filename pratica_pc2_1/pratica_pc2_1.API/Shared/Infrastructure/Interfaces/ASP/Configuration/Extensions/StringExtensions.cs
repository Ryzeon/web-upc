using System.Text.RegularExpressions;

namespace pratica_pc2_1.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions
{
    public static partial class StringExtensions
    {
        public static string ToKebabCase(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            return KebabCaseRegex().Replace(text, "-$1") 
                .Trim()
                .ToLower();
        }

        private static Regex KebabCaseRegex()
        {
            return new Regex("(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", RegexOptions.Compiled);
        }
    }
}
