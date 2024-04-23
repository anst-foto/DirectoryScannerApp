var path = @"C:\Users\Elena\Documents\pdf.pdf";
var fileInfo = new FileInfo(path);
if (fileInfo.Exists)
{
    Console.WriteLine($"Имя файла: {fileInfo.Name}");
    Console.WriteLine(fileInfo.FullName);
}