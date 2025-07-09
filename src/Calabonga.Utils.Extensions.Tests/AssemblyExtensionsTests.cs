namespace Calabonga.Utils.Extensions.Tests;

public class AssemblyExtensionsTests
{
    [Fact]
    public void Test_MetadataVersion_FromString_toFullString_withoutMetadata()
    {
        const string versionString = "2.8.1-beta.11";
        var version = versionString.GetSemanticVersion().ToFullString();

        Assert.Equal("2.8.1 beta.11", version);
    }

    [Fact]
    public void Test_MetadataVersion_FromString_toFullString_withMetadata()
    {
        const string versionString = "2.8.1-beta.11+088e43f9f7ddb580a81408eadabc114b6a7cd6bf";
        var version = versionString.GetSemanticVersion().ToFullString();

        Assert.Equal("2.8.1 beta.11 (088e43f)", version);
    }

    [Fact]
    public void Test_MetadataVersion_FromString_toString()
    {
        const string versionString = "2.8.1+088e43f9f7ddb580a81408eadabc114b6a7cd6bf";
        var version = versionString.GetSemanticVersion().ToString();

        Assert.Equal("2.8.1", version);
    }

    [Fact]
    public void Test_MetadataVersion_FromString_toString_withPrerelease()
    {
        const string versionString = "2.8.1-beta.1.2+088e43f9f7ddb580a81408eadabc114b6a7cd6bf";
        var version = versionString.GetSemanticVersion().ToString();

        Assert.Equal("2.8.1 beta.1.2", version);
    }

    [Fact]
    public void Test_MetadataVersion_FromString()
    {
        const string versionString = "2.8.1-beta.1.2+088e43f9f7ddb580a81408eadabc114b6a7cd6bf";
        var version = versionString.GetSemanticVersion();

        Assert.IsType<SemanticVersion>(version);
        Assert.Equal("088e43f9f7ddb580a81408eadabc114b6a7cd6bf", version.Metadata);
    }

    [Fact]
    public void Test_PrereleaseVersion_FromString3()
    {
        const string versionString = "2.8.1-beta.1.2+088e43f9f7ddb580a81408eadabc114b6a7cd6bf";
        var version = versionString.GetSemanticVersion();

        Assert.IsType<SemanticVersion>(version);
        Assert.Equal("beta.1.2", version.Prerelease);
    }

    [Fact]
    public void Test_PrereleaseVersion_FromString2()
    {
        const string versionString = "2.8.1-beta.1+088e43f9f7ddb580a81408eadabc114b6a7cd6bf";
        var version = versionString.GetSemanticVersion();

        Assert.IsType<SemanticVersion>(version);
        Assert.Equal("beta.1", version.Prerelease);
    }

    [Fact]
    public void Test_PrereleaseVersion_FromString()
    {
        const string versionString = "2.8.1-beta1+088e43f9f7ddb580a81408eadabc114b6a7cd6bf";
        var version = versionString.GetSemanticVersion();

        Assert.IsType<SemanticVersion>(version);
        Assert.Equal("beta1", version.Prerelease);
    }

    [Fact]
    public void Test_PatchVersion_FromString()
    {
        const string versionString = "2.8.0-beta1+088e43f9f7ddb580a81408eadabc114b6a7cd6bf";
        var version = versionString.GetSemanticVersion();

        Assert.IsType<SemanticVersion>(version);
        Assert.Equal(0, version.Patch);
    }

    [Fact]
    public void Test_MinorVersion_FromString()
    {
        const string versionString = "2.8.0-beta1+088e43f9f7ddb580a81408eadabc114b6a7cd6bf";
        var version = versionString.GetSemanticVersion();

        Assert.IsType<SemanticVersion>(version);
        Assert.Equal(8, version.Minor);
    }

    [Fact]
    public void Test_MajorVersion_FromString()
    {
        const string versionString = "2.8.0-beta1+088e43f9f7ddb580a81408eadabc114b6a7cd6bf";
        var version = versionString.GetSemanticVersion();

        Assert.IsType<SemanticVersion>(version);
        Assert.Equal(2, version.Major);
    }

    [Fact]
    public void Test_Type_SemanticVersion_FromAssembly()
    {
        var version = typeof(AssemblyExtensions).Assembly.GetSemanticVersion();

        Assert.IsType<SemanticVersion>(version);
    }

    [Fact]
    public void Test_MajorVersion_FromAssembly()
    {
        var version = typeof(AssemblyExtensions).Assembly.GetSemanticVersion();

        Assert.IsType<SemanticVersion>(version);
        Assert.InRange(version.Major, 1, int.MaxValue);
    }


    [Fact]
    public void Test_MinorVersion_FromAssembly()
    {
        var version = typeof(AssemblyExtensions).Assembly.GetSemanticVersion();

        Assert.IsType<SemanticVersion>(version);
        Assert.InRange(version.Minor, 1, int.MaxValue);
    }
}
