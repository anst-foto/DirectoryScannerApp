namespace DirectoryScannerApp.CoreLib.Test;

public class ErrorTest
{
    [Fact]
    public void ThrowIfNullOrEmptyTest()
    {
        Assert.Throws<ArgumentNullException>(() => Error.ThrowIfNullOrEmpty(
            "",
            "",
            ErrorType.Unknown));
    }

    [Fact]
    public void ThrowIfNegativeTest()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Error.ThrowIfNegative(
            -1,
            "",
            ErrorType.Unknown));
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
            new List<string>(),
            ErrorType.Unknown));
    }
}
