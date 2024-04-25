namespace DirectoryScannerApp.CoreLib;

//TODO Добавить unit-тесты
/// <summary>
/// Сканирует директории
/// </summary>
public sealed class DirectoryScanner
{
    private readonly string? _directoryPath;
    /// <value>Директория для сканирования</value>
    public required string? DirectoryPath
    {
        get => _directoryPath;
        init
        {
            Error.ThrowIfNullOrEmpty(value, nameof(DirectoryPath), Error.Messages[ErrorType.EmptyDirectoryPath]);
            Error.ThrowIfNotExist(value);
            //TODO Сделать проверку на длинну имени директории
            
            _directoryPath = value; 
        }
    }

    /// <summary>
    /// Получает списоком информацию о файлах в директории
    /// </summary>
    /// <returns>Список информации о файлах в директории</returns>
    public IEnumerable<FileInfoDto> Scan()
    {
        if (DirectoryPath == null) yield break;
        
        var directoryInfo = new DirectoryInfo(DirectoryPath);
        var files = directoryInfo.GetFiles();
        
        Error.ThrowIfEmptyCollection(files, Error.Messages[ErrorType.EmptyDirectory]);

        foreach (var file in files)
        {
            yield return new FileInfoDto()
            {
                Name = file.Name,
                Extension = file.Extension,
                Path = file.FullName,
                Size = file.Length
            };
        }
    }
}