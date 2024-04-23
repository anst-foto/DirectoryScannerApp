using System.Text.Json;

namespace DirectoryScannerApp.CoreLib;

//TODO Добавить unit-тесты
public static class OutputFileInfo //TODO Добавить наследование
{
    //TODO Добавить поддержку логгирования 
    
    //TODO Рассказать про XMLDoc-комментарии
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