using Semver;
using System.Diagnostics;
using System.Reflection;

namespace Calabonga.Utils.Extensions
{
    /// <summary>
    /// Sematic Version Extraction extensions
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Returns SemVer from assembly
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static SemVersion GetVersionFromAssembly(this Assembly source)
        {
            if (source is null)
            {
                return new SemVersion(0, 0, 0);
            }

            var version = FileVersionInfo.GetVersionInfo(source.Location).ProductVersion
                          ?? source.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;

            SemVersion.TryParse(version, SemVersionStyles.Any, out var versionResult);

            return versionResult;
        }

        /// <summary>
        /// Extract SemVer from string
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static SemVersion TryParseVersionFromString(this string version)
        {
            return SemVersion.TryParse(version, SemVersionStyles.Any, out var versionResult) ? versionResult : new SemVersion(0, 0, 0);
        }
    }
}
