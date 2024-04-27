using Logger;

namespace DirectoryScannerApp.CoreLib;

//TODO Добавить unit-тесты
/// <summary>
///     Сканирует директории
/// </summary>
public sealed class DirectoryScanner
{
    public ILogger? Logger { get; init; }

    private readonly string? _directoryPath;
    /// <value>Директория для сканирования</value>
    public required string? DirectoryPath
    {
        get => _directoryPath;
        init
        {
            Error.ThrowIfNullOrEmpty(value, nameof(DirectoryPath), ErrorType.EmptyDirectoryPath, Logger);
            Error.ThrowIfNotExistsDirectory(value, Logger);
            //TODO Сделать проверку на длинну имени директории

            _directoryPath = value;
            Logger?.Success($"Установлена директория {value}");
        }
    }

    /// <summary>
    ///     Получает списоком информацию о файлах в директории
    /// </summary>
    /// <returns>Список информации о файлах в директории</returns>
    public IEnumerable<FileInfoDto> Scan()
    {
        if (DirectoryPath == null)
        {
            Logger?.Error($"{Error.Messages[ErrorType.EmptyDirectoryPath]} ({nameof(DirectoryPath)})");
            yield break;
        }

        var directoryInfo = new DirectoryInfo(DirectoryPath);
        var files = directoryInfo.GetFiles();
        Logger?.Info($"Всего файлов в директории {DirectoryPath} {files.Length}");

        Error.ThrowIfEmptyCollection(files, ErrorType.EmptyDirectory, Logger);

        foreach (var file in files)
        {
            var fileInfoDto = new FileInfoDto
            {
                Name = file.Name, Extension = file.Extension, Path = file.FullName, Size = file.Length
            };
            Logger?.Info($"Информация о файле {fileInfoDto.Name}: {fileInfoDto.Size}");

            yield return fileInfoDto;
        }
    }
}
