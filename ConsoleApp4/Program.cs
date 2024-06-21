using System;
using System.IO;

public class FolderSizeCalculator
{
    public static long CalculateFolderSize(string directoryPath)
    {
        long totalSize = 0;

        
        if (!Directory.Exists(directoryPath))
        {
            throw new ArgumentException("Папка не существует.");
        }

        
        foreach (string filePath in Directory.EnumerateFiles(directoryPath, "*", SearchOption.AllDirectories))
        {
            FileInfo fileInfo = new FileInfo(filePath);
            totalSize += fileInfo.Length;
        }

        return totalSize;
    }

    public static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Необходимо указать путь к папке в качестве аргумента.");
            return;
        }

        string folderPath = args[0];

        try
        {
            long sizeInBytes = CalculateFolderSize(folderPath);
            Console.WriteLine($"Размер папки '{folderPath}': {sizeInBytes} байт");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

