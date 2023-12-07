using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // 1) Створення каталогу OOP_lab08 на диску D:
        string directoryPath = @"D:\OOP_lab08";
        Directory.CreateDirectory(directoryPath);

        // 2) Створення необхідних каталогів
        string KNms1B23 = "KNms1-B23"; 
        string Veretko = "Veretko"; 

        string[] subDirectories = { KNms1B23, Veretko, "Sources", "Reports", "Texts" };

        foreach (string subDir in subDirectories)
        {
            string path = Path.Combine(directoryPath, subDir);
            Directory.CreateDirectory(path);
        }

        // 3) Копіювання каталогів Texts, Sources та Reports до каталогу Ваше_прізвище
        string VeretkoPath = Path.Combine(directoryPath, Veretko);

        string textsPath = Path.Combine(directoryPath, "Texts");
        string sourcesPath = Path.Combine(directoryPath, "Sources");
        string reportsPath = Path.Combine(directoryPath, "Reports");

        DirectoryCopy(textsPath, Path.Combine(VeretkoPath, "Texts"), true);
        DirectoryCopy(sourcesPath, Path.Combine(VeretkoPath, "Sources"), true);
        DirectoryCopy(reportsPath, Path.Combine(VeretkoPath, "Reports"), true);

        // 4) Переміщення каталогу Ваше_прізвище до каталогу Номер_вашої_групи
        string groupPath = Path.Combine(directoryPath, KNms1B23);
        Directory.Move(VeretkoPath, Path.Combine(groupPath, Veretko));

        // 5) Створення текстового файлу dirinfo.txt у каталозі Texts з інформацією про каталог Texts
        string dirInfoFilePath = Path.Combine(directoryPath, "Texts", "dirinfo.txt");
        DirectoryInfo textsDirectoryInfo = new DirectoryInfo(textsPath);

        using (StreamWriter writer = new StreamWriter(dirInfoFilePath))
        {
            writer.WriteLine($"Full path: {textsDirectoryInfo.FullName}");
            writer.WriteLine($"Creation time: {textsDirectoryInfo.CreationTime}");
            writer.WriteLine($"Last access time: {textsDirectoryInfo.LastAccessTime}");
            writer.WriteLine($"Number of files: {textsDirectoryInfo.GetFiles().Length}");
            writer.WriteLine($"Number of subdirectories: {textsDirectoryInfo.GetDirectories().Length}");
            
        }

        Console.WriteLine("Операції з файловою системою виконані успішно!");
    }

    // Метод для рекурсивного копіювання вмісту каталогу
    static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
    {
        DirectoryInfo dir = new DirectoryInfo(sourceDirName);
        DirectoryInfo[] dirs = dir.GetDirectories();

        if (!dir.Exists)
        {
            throw new DirectoryNotFoundException($"Source directory does not exist or could not be found: {sourceDirName}");
        }

        if (!Directory.Exists(destDirName))
        {
            Directory.CreateDirectory(destDirName);
        }

        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            string temppath = Path.Combine(destDirName, file.Name);
            file.CopyTo(temppath, false);
        }

        if (copySubDirs)
        {
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(subdir.FullName, temppath, copySubDirs);
            }
        }
    }
}
