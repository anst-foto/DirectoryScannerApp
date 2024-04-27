namespace DirectoryScannerApp.CoreLib;

//TODO Добавить unit-тесты
/// <summary>
///     Информация о файле
/// </summary>
public record FileInfoDto
{
    private readonly string? _extension;
    private readonly string? _name;

    private readonly string? _path;

    private readonly long _size;

    /// <value>Имя файла</value>
    public required string? Name
    {
        get => _name;
        init
        {
            Error.ThrowIfNullOrEmpty(value, nameof(Name), ErrorType.EmptyFileName);
            _name = value;
        }
    }

    /// <value>Расширение файла</value>
    public required string? Extension
    {
        get => _extension;
        init
        {
            Error.ThrowIfNullOrEmpty(value, nameof(Extension), ErrorType.EmptyExtension);
            _extension = value;
        }
    }

    /// <value>Путь к файлу</value>
    public required string? Path
    {
        get => _path;
        init
        {
            Error.ThrowIfNullOrEmpty(value, nameof(Path), ErrorType.EmptyFilePath);
            _path = value;
        }
    }

    /// <value>Размер файла</value>
    public required long Size
    {
        get => _size;
        init
        {
            Error.ThrowIfNegative(value, nameof(Size), ErrorType.NegativeFileSize);
            _size = value;
        }
    }
}
