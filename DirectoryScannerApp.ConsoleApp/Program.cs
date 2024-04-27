using DirectoryScannerApp.CoreLib;
using DirectoryScannerApp.CoreLib.OutputFile;
using Logger.Console;

var scanner = new DirectoryScanner { Logger = new LogToConsole(), DirectoryPath = @"C:\Users\Elena\Downloads" };

var result = scanner.Scan();

var file = new OutputFileInfoToJson(result, "file_infos.json", new LogToConsole());
file.WriteAll();
