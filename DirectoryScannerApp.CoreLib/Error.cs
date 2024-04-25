namespace DirectoryScannerApp.CoreLib;

/// <summary>Тип ошибок</summary>
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
/// <summary>Класс для обработки ошибок и выброса исключений</summary>
public static class Error
{
    /// <summary>Словарь сообщений об ошибках</summary>
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
    
    /// <summary>
    /// Прповерка строки на пустоту
    /// </summary>
    /// <param name="value">Проверяемая строка</param>
    /// <param name="paramName">Имя переменной (свойства), которое проверяется</param>
    /// <param name="message">Сообщение об ошибке</param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void ThrowIfNullOrEmpty(string? value, string paramName, string message) //TODO Заменить параметр message со string на ErrorType
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(paramName, message);
        }
    }

    /// <summary>
    /// Проверка числового значения на то, что оно меньше <paramref name="i"/>
    /// </summary>
    /// <param name="value">Проверяемое число</param>
    /// <param name="i">Число с которым сравнивается</param>
    /// <param name="paramName">Имя переменной (свойства), которое проверяется</param>
    /// <param name="message">Сообщение об ошибке</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void ThrowIfLessThan(long value, int i, string paramName, string message) //TODO Переименовать аргумент "i"
    {
        if (value < i) throw new ArgumentOutOfRangeException(paramName, message);
    }

    /// <summary>
    /// Проверка числового значения на отрицательное число
    /// </summary>
    /// <param name="value">Проверяемое число</param>
    /// <param name="paramName">Имя переменной (свойства), которое проверяется</param>
    /// <param name="message">Сообщение об ошибке</param>
    public static void ThrowIfNegative(long value, string paramName, string message)
    {
        ThrowIfLessThan(value, 0, paramName, message);
    }

    /// <summary>
    /// Проверка на существование директории или файла
    /// </summary>
    /// <param name="path">Путь к файлу или директории</param>
    /// <exception cref="DirectoryNotFoundException"></exception>
    /// <exception cref="FileNotFoundException"></exception>
    public static void ThrowIfNotExist(string? path)
    {
        if (!Directory.Exists(path)) 
            throw new DirectoryNotFoundException($"{Messages[ErrorType.NotExistDirectory]} ({path})"); //TODO Выделить в отдельный метод
        
        if (!File.Exists(path))
            throw new FileNotFoundException($"{Messages[ErrorType.NotExistFile]} ({path})"); //TODO Выделить в отдельный метод
    }

    /// <summary>
    /// Проверка коллекции на пустоту
    /// </summary>
    /// <param name="collection">Проверяемая коллекция</param>
    /// <param name="message">Сообщение об ошибке</param>
    /// <exception cref="ArgumentException"></exception>
    public static void ThrowIfEmptyCollection(IEnumerable<object> collection, string message)
    {
        if (!collection.Any()) throw new ArgumentException(message);
    }
}