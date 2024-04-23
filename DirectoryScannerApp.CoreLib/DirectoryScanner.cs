namespace DirectoryScannerApp.CoreLib;

//TODO Добавить unit-тесты
public sealed class DirectoryScanner //TODO Рассказать про sealed
{
    private readonly string _directoryPath;
    public required string DirectoryPath
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

    public IEnumerable<FileInfoDto> Scan()
    {
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