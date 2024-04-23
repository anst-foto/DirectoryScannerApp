namespace DirectoryScannerApp.CoreLib;

public enum ErrorType
{
    Unknown,
    EmptyFileName,
    EmptyExtension,
    NegativeFileSize,
    EmptyFilePath,
    EmptyDirectoryPath,
    NotExistDirectory,
    NotExistFile,
    EmptyDirectory,
}

//TODO Добавить unit-тесты
public static class Error
{
    public static readonly Dictionary<ErrorType, string> Messages = new()
    {
        { ErrorType.Unknown , "Неизвестная ошибка." },
        { ErrorType.EmptyFileName, "Имя файла не может быть пустым." },
        { ErrorType.EmptyExtension, "Расширение файла не может быть пустым." },
        { ErrorType.NegativeFileSize , "Размер файла не может быть отрицательным." },
        { ErrorType.EmptyFilePath, "Путь к файлу не может быть пустым." },
        { ErrorType.EmptyDirectoryPath, "Путь к директории не может быть пустым." },
        { ErrorType.NotExistDirectory, "Директория не существует." },
        { ErrorType.NotExistFile, "Файл не существует." },
        { ErrorType.EmptyDirectory, "Директория не может быть пустой."}
    };
    
    public static void ThrowIfNullOrEmpty(string value, string paramName, string message) //TODO Заменить параметр message со string на ErrorType
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(paramName, message);
        }
    }

    public static void ThrowIfLessThan(long value, int i, string sizeName, string message) //TODO Переименовать аргумент "i"
    {
        if (value < i) throw new ArgumentOutOfRangeException(sizeName, message);
    }

    public static void ThrowIfNegative(long value, string paramName, string message)
    {
        ThrowIfLessThan(value, 0, paramName, message);
    }

    public static void ThrowIfNotExist(string path)
    {
        if (!Directory.Exists(path)) 
            throw new DirectoryNotFoundException($"{Messages[ErrorType.NotExistDirectory]} ({path})"); //TODO Выделить в отдельный метод
        
        if (!File.Exists(path))
            throw new FileNotFoundException($"{Messages[ErrorType.NotExistFile]} ({path})"); //TODO Выделить в отдельный метод
    }

    public static void ThrowIfEmptyCollection(IEnumerable<object> collection, string message)
    {
        if (!collection.Any()) throw new ArgumentException(message);
    }
}