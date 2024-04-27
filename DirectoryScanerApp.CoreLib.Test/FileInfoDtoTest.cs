using DirectoryScannerApp.CoreLib;

namespace DirectoryScanerApp.CoreLib.Test;

public class FileInfoDtoTest
{
    [Fact]
    public void NameTest()
    {
        Assert.Throws<ArgumentNullException>(() => new FileInfoDto()
        {
            Name = null,
            Extension = "",
            Path = " ",
            Size = -1,
        });
    }

    [Fact]
    public void ExtensionTest()
    {
        Assert.Throws<ArgumentNullException>(() => new FileInfoDto()
        {
            Name = "null",
            Extension = "",
            Path = " ",
            Size = -1,
        });
    }

    [Fact]
    public void PathTest()
    {
        Assert.Throws<ArgumentNullException>(() => new FileInfoDto()
        {
            Name = "null",
            Extension = "null",
            Path = " ",
            Size = -1,
        });
    }

    [Fact]
    public void SizeTest()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new FileInfoDto()
        {
            Name = "null",
            Extension = "null",
            Path = "null",
            Size = -1,
        });
    }
}
