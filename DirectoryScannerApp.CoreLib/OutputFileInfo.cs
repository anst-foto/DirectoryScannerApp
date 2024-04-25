using System.Text.Json;

namespace DirectoryScannerApp.CoreLib;

//TODO Добавить unit-тесты
/// <summary>
/// Класс для записи информации о файлах в файл
/// </summary>
public static class OutputFileInfo //TODO Добавить наследование
{
    //TODO Добавить поддержку логгирования 
    
    /// <summary>
    /// Сохраняет информацию о файлах в json-файл
    /// </summary>
    /// <param name="files">Список информации о файлах</param>
    /// <param name="path">Путь к файлу для сохранения</param>
    /// <exception cref="Exception">Ошибка сохранения данных</exception>
    public static void WriteAllToJson(IEnumerable<FileInfoDto> files, string path = "output.json")
    {
        try
        {
            var json = JsonSerializer.Serialize(files);
            File.WriteAllText(path, json);
        }
        catch (Exception e)
        {
            //TODO: Добавить логгирование
            throw new Exception(Error.Messages[ErrorType.Unknown], e);
        }
    }
}