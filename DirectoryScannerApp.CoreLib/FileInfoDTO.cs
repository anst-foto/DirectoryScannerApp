namespace DirectoryScannerApp.CoreLib;

//TODO Добавить unit-тесты
public record FileInfoDto
{
    private readonly string _name;
    public required string Name
    {
        get => _name;
        init
        {
            Error.ThrowIfNullOrEmpty(value, nameof(Name), Error.Messages[ErrorType.EmptyFileName]);
            _name = value;
        }
    }
    
    private readonly string _extension;
    public required string Extension
    {
        get => _extension;
        init
        {
            Error.ThrowIfNullOrEmpty(value, nameof(Extension), Error.Messages[ErrorType.EmptyExtension]);
            _extension = value;
        }
    }
    
    private readonly string _path;

    public required string Path
    {
        get => _path;
        init
        {
            Error.ThrowIfNullOrEmpty(value, nameof(Path), Error.Messages[ErrorType.EmptyFilePath]);
            _path = value;
        }
    }
    
    private readonly long _size;
    public required long Size
    {
        get => _size;
        init
        {
            Error.ThrowIfNegative(value, nameof(Size), Error.Messages[ErrorType.NegativeFileSize]);
            _size = value;
        }
    }
}