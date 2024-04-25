namespace DirectoryScannerApp.CoreLib.OutputFile;

/// <summary>
///     Интерфейс для записи информации в файл
/// </summary>
public interface IOutputFileInfo
{
    /// <summary>
    ///     Записать информацию в файл
    /// </summary>
    public void WriteAll();
}
