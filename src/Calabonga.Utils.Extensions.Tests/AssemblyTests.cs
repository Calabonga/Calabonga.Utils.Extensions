using Semver;

namespace Calabonga.Utils.Extensions.Tests;
public class AssemblyTests
{
    [Fact]
    public void Version_Main_shouldNot_be_null()
    {
        var type = typeof(AssemblyExtensions);
        var version = type.Assembly.GetVersionFromAssembly();

        Assert.NotNull(version);
    }

    [Fact]
    public void Version_Test_shouldNot_be_null()
    {
        var type = GetType();
        var version = type.Assembly.GetVersionFromAssembly();

        Assert.NotNull(version);
    }

    [Fact]
    public void Version_Main_should_be_SemVer()
    {
        var type = typeof(AssemblyExtensions);
        var version = type.Assembly.GetVersionFromAssembly();

        Assert.IsType<SemVersion>(version);
    }

    [Fact]
    public void Version_Test_should_be_SemVer()
    {
        var type = GetType();
        var version = type.Assembly.GetVersionFromAssembly();

        Assert.IsType<SemVersion>(version);
    }

    [Fact]
    public void Version_from_string_shouldNot_be_null()
    {
        var versionString = "1.0.0";
        var version = versionString.TryParseVersionFromString();

        Assert.NotNull(version);
    }

    [Fact]
    public void Version_from_string_shouldNot_be_SemVer_type()
    {
        var versionString = "1.0.0";
        var version = versionString.TryParseVersionFromString();

        Assert.IsType<SemVersion>(version);
    }
}
