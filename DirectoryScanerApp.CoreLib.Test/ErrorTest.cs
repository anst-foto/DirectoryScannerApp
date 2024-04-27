using DirectoryScannerApp.CoreLib;

namespace DirectoryScanerApp.CoreLib.Test;

public class ErrorTest
{
    [Fact]
    public void ThrowIfNullOrEmptyTest()
    {
        Assert.Throws<ArgumentNullException>(() => Error.ThrowIfNullOrEmpty(
            value:"",
            paramName:"",
            errorType: ErrorType.Unknown));
    }

    [Fact]
    public void ThrowIfNegativeTest()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Error.ThrowIfNegative(
            value:-1,
            paramName:"",
            errorType: ErrorType.Unknown));
    }

    [Fact]
    public void ThrowIfNotExistsDirectoryTest()
    {
        Assert.Throws<DirectoryNotFoundException>(() => Error.ThrowIfNotExistsDirectory(""));
    }

    [Fact]
    public void ThrowIfNotExistsFileTest()
    {
        Assert.Throws<FileNotFoundException>(() => Error.ThrowIfNotExistsFile(""));
    }

    [Fact]
    public void ThrowIfEmptyCollectionTest()
    {
        Assert.Throws<ArgumentException>(() => Error.ThrowIfEmptyCollection(
            collection: new List<string>(),
            errorType: ErrorType.Unknown));
    }
}
