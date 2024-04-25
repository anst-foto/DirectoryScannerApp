﻿namespace DirectoryScannerApp.CoreLib.OutputFile;

/// <summary>
///     Базовый класс для сохранения информации о файлах в файле
/// </summary>
public abstract class OutputFileInfoBase : IOutputFileInfo
{
    /// <summary>Информация о файлах</summary>
    protected readonly IEnumerable<FileInfoDto> FileInfos;

    /// <summary>Путь к файлу</summary>
    protected readonly string FilePath;

    /// <summary>
    ///     Конструктор класса
    /// </summary>
    /// <param name="fileInfos">Список информации о файлах</param>
    /// <param name="filePath">Путь к файлу</param>
    protected OutputFileInfoBase(IEnumerable<FileInfoDto> fileInfos, string filePath)
    {
        this.FileInfos = fileInfos;
        this.FilePath = filePath;
    }

    /// <summary>
    ///     Сохранение информации о файлах в файл
    /// </summary>
    public abstract void WriteAll();
}
