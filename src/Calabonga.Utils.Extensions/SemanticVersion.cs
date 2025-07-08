namespace Calabonga.Utils.Extensions
{
    public sealed class SemanticVersion
    {
        private SemanticVersion(int major, int minor, int patch, string? prerelease, string? metadata)
        {
            Major = major;
            Minor = minor;
            Patch = patch;
            Prerelease = prerelease;
            Metadata = metadata;
        }

        public static SemanticVersion CreateVersion(int major, int minor, int patch, string prerelease, string metadata)
        {
            return new SemanticVersion(major, minor, patch, prerelease, metadata);
        }

        public static SemanticVersion CreateVersionEmpty()
        {
            return new SemanticVersion(0, 0, 0, null, null);
        }

        public static SemanticVersion CreateVersionWithPrerelease(int major, int minor, int patch, string prerelease)
        {
            return new SemanticVersion(major, minor, patch, prerelease, null);
        }

        public static SemanticVersion CreateVersionWithMetadata(int major, int minor, int patch, string metadata)
        {
            return new SemanticVersion(major, minor, patch, null, metadata);
        }

        /// <summary>
        /// The major version part.
        /// </summary>
        public int Major { get; }

        /// <summary>
        /// The minor version part.
        /// </summary>
        public int Minor { get; }

        /// <summary>
        /// The patch version part.
        /// </summary>
        public int Patch { get; }

        /// <summary>
        /// The prerelease version part.
        /// </summary>
        public string? Prerelease { get; }

        /// <summary>
        /// The metadata version part.
        /// </summary>
        public string? Metadata { get; }
    }
}
