using System.Text.Json;

namespace DirectoryScannerApp.CoreLib.OutputFile;

/// <summary>
///     Класс для сохранения информации о файлах в JSON-файле
/// </summary>
public class OutputFileInfoToJson : OutputFileInfoBase
{
    /// <summary>
    ///     Конструктор класса
    /// </summary>
    /// <param name="fileInfos">Список информации о файлах</param>
    /// <param name="filePath">Путь к файлу. По умолчанию - file_infos.json</param>
    public OutputFileInfoToJson(IEnumerable<FileInfoDto> fileInfos, string filePath = "file_infos.json")
        : base(fileInfos, filePath)
    {
    }

    /// <summary>
    ///     Сохранение информации о файлах в JSON-файл
    /// </summary>
    /// <exception cref="Exception"></exception>
    public override void WriteAll()
    {
        try
        {
            var json = JsonSerializer.Serialize(FileInfos);
            File.WriteAllText(FilePath, json);
        }
        catch (Exception e)
        {
            //TODO: Добавить логгирование
            throw new Exception(Error.Messages[ErrorType.Unknown], e);
        }
    }
}
