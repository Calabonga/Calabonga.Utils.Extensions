using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Calabonga.Utils.Extensions
{
    /// <summary>
    /// Semantic Versions
    /// </summary>
    public static class AssemblyExtensions
    {
        public static string ToFullString(this SemanticVersion source)
        {
            if (string.IsNullOrEmpty(source.Metadata))
            {
                return source.ToString();
            }

            return $"{source} ({source.Metadata[..7]})";
        }

        public static SemanticVersion GetSemanticVersion(this string? source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return SemanticVersion.CreateVersionEmpty();
            }
            const string pattern = @"^(?<major>0|[1-9]\d*)\.(?<minor>0|[1-9]\d*)\.(?<patch>0|[1-9]\d*)(?:-(?<prerelease>(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*)(?:\.(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*))*))?(?:\+(?<buildmetadata>[0-9a-zA-Z-]+(?:\.[0-9a-zA-Z-]+)*))?$";

            var match = Regex.Match(source, pattern, RegexOptions.Multiline | RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.CultureInvariant);

            if (match.Success)
            {
                return SemanticVersion.CreateVersion(
                    int.Parse(match.Groups["major"].Value),
                    int.Parse(match.Groups["minor"].Value),
                    int.Parse(match.Groups["patch"].Value),
                    match.Groups["prerelease"].Value,
                    match.Groups["buildmetadata"].Value);
            }

            return SemanticVersion.CreateVersionEmpty();
        }

        public static SemanticVersion GetSemanticVersion(this Assembly source)
        {
            var productVersion = FileVersionInfo.GetVersionInfo(source.Location).ProductVersion;
            if (productVersion is null)
            {
                return SemanticVersion.CreateVersionEmpty();
            }

            return GetSemanticVersion(productVersion);
        }

    }
}
