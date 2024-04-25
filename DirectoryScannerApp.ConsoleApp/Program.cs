using DirectoryScannerApp.CoreLib;

var path = @"C:\Users\Elena\Documents\pdf.pdf";
var fileInfo = new FileInfo(path);
if (fileInfo.Exists)
{
    Console.WriteLine($"Имя файла: {fileInfo.Name}");
    Console.WriteLine(fileInfo.FullName);
}

FileInfoDto? f = null;

try
{
    f = new FileInfoDto { Name = "", Extension = "", Path = "", Size = -1 };
}
catch (Exception e)
{
    Console.WriteLine(e);
}

Console.WriteLine(f?.FullName);
