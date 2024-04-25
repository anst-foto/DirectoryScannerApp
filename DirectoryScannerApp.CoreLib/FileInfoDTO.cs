namespace DirectoryScannerApp.CoreLib;

//TODO Добавить unit-тесты
/// <summary>
/// Информация о файле
/// </summary>
public record FileInfoDto
{
    private readonly string? _name;
    /// <value>Имя файла</value>
    public required string? Name
    {
        get => _name;
        init
        {
            Error.ThrowIfNullOrEmpty(value, nameof(Name), Error.Messages[ErrorType.EmptyFileName]);
            _name = value;
        }
    }
    
    private readonly string? _extension;
    /// <value>Расширение файла</value>
    public required string? Extension
    {
        get => _extension;
        init
        {
            Error.ThrowIfNullOrEmpty(value, nameof(Extension), Error.Messages[ErrorType.EmptyExtension]);
            _extension = value;
        }
    }
    
    /// <value>Полное имя файла</value>
    public string FullName => $"{Name}.{Extension}";
    
    private readonly string? _path;
    /// <value>Путь к файлу</value>
    public required string? Path
    {
        get => _path;
        init
        {
            Error.ThrowIfNullOrEmpty(value, nameof(Path), Error.Messages[ErrorType.EmptyFilePath]);
            _path = value;
        }
    }
    
    private readonly long _size;
    /// <value>Размер файла</value>
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