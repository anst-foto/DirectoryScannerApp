using System.Text.Encodings.Web;
using System.Text.Json;
using Logger;

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
    /// <param name="logger">Логгер</param>
    public OutputFileInfoToJson(IEnumerable<FileInfoDto> fileInfos, string filePath = "file_infos.json",
        ILogger? logger = null)
        : base(fileInfos, filePath, logger)
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
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            var json = JsonSerializer.Serialize(FileInfos, jsonOptions);
            File.WriteAllText(FilePath, json);
            Logger?.Success("Информация о файлах сохранена в JSON-файл");
        }
        catch (Exception e)
        {
            Logger?.Error(e.Message);
            throw new Exception(Error.Messages[ErrorType.Unknown], e);
        }
    }
}
