using Logger;

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
    EmptyDirectory
}

//TODO Добавить unit-тесты
/// <summary>Класс для обработки ошибок и выброса исключений</summary>
public static class Error
{
    /// <summary>Словарь сообщений об ошибках</summary>
    public static readonly Dictionary<ErrorType, string> Messages = new()
    {
        { ErrorType.Unknown, "Неизвестная ошибка." },
        { ErrorType.EmptyFileName, "Имя файла не может быть пустым." },
        { ErrorType.EmptyExtension, "Расширение файла не может быть пустым." },
        { ErrorType.NegativeFileSize, "Размер файла не может быть отрицательным." },
        { ErrorType.EmptyFilePath, "Путь к файлу не может быть пустым." },
        { ErrorType.EmptyDirectoryPath, "Путь к директории не может быть пустым." },
        { ErrorType.NotExistDirectory, "Директория не существует." },
        { ErrorType.NotExistFile, "Файл не существует." },
        { ErrorType.EmptyDirectory, "Директория не может быть пустой." }
    };

    /// <summary>
    ///     Прповерка строки на пустоту
    /// </summary>
    /// <param name="value">Проверяемая строка</param>
    /// <param name="paramName">Имя переменной (свойства), которое проверяется</param>
    /// <param name="errorType">Тип ошибки</param>
    /// /// <param name="logger">Объект логгера</param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void ThrowIfNullOrEmpty(string? value, string paramName, ErrorType errorType, ILogger? logger = null)
    {
        if (!string.IsNullOrWhiteSpace(value)) return;

        logger?.Error($"[{paramName}] {Messages[errorType]}");
        throw new ArgumentNullException(paramName, Messages[errorType]);
    }

    /// <summary>
    ///     Проверка числового значения на то, что оно меньше <paramref name="number" />
    /// </summary>
    /// <param name="value">Проверяемое число</param>
    /// <param name="number">Число с которым сравнивается</param>
    /// <param name="paramName">Имя переменной (свойства), которое проверяется</param>
    /// <param name="errorType">Тип ошибки</param>
    /// /// <param name="logger">Объект логгера</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static void ThrowIfLessThan(long value, int number, string paramName, ErrorType errorType, ILogger? logger = null)
    {
        if (value >= number)
        {
            return;
        }

        logger?.Error($"[{paramName}] {Messages[errorType]}");
        throw new ArgumentOutOfRangeException(paramName, Messages[errorType]);
    }

    /// <summary>
    ///     Проверка числового значения на отрицательное число
    /// </summary>
    /// <param name="value">Проверяемое число</param>
    /// <param name="paramName">Имя переменной (свойства), которое проверяется</param>
    /// <param name="errorType">Тип ошибки</param>
    /// <param name="logger">Объект логгера</param>
    public static void ThrowIfNegative(long value, string paramName, ErrorType errorType, ILogger? logger = null)
    {
        ThrowIfLessThan(value, 0, paramName, errorType, logger);
    }

    /// <summary>
    /// Проверка на существование директории
    /// </summary>
    /// <param name="path">Путь к директории</param>
    /// <param name="logger">Объект логгера</param>
    /// <exception cref="DirectoryNotFoundException"></exception>
    public static void ThrowIfNotExistsDirectory(string? path, ILogger? logger = null)
    {
        if (Directory.Exists(path)) return;

        logger?.Error($"{Messages[ErrorType.NotExistDirectory]} ({path})");
        throw new DirectoryNotFoundException($"{Messages[ErrorType.NotExistDirectory]} ({path})");
    }

    /// <summary>
    /// Проверка на существование файла
    /// </summary>
    /// <param name="path">Путь к файлу</param>
    /// <param name="logger">Объект логгера</param>
    /// <exception cref="FileNotFoundException"></exception>
    public static void ThrowIfNotExistsFile(string? path, ILogger? logger = null)
    {
        if (File.Exists(path))
        {
            return;
        }

        logger?.Error($"{Messages[ErrorType.NotExistFile]} ({path})");
        throw new FileNotFoundException(
            $"{Messages[ErrorType.NotExistFile]} ({path})");
    }

    /// <summary>
    ///     Проверка коллекции на пустоту
    /// </summary>
    /// <param name="collection">Проверяемая коллекция</param>
    /// <param name="errorType">Тип ошибки</param>
    /// <param name="logger">Объект логгера</param>
    /// <exception cref="ArgumentException"></exception>
    public static void ThrowIfEmptyCollection(IEnumerable<object> collection, ErrorType errorType, ILogger? logger = null)
    {
        if (collection.Any())
        {
            return;
        }

        logger?.Error($"{Messages[errorType]}");
        throw new ArgumentException(Messages[errorType]);
    }
}
