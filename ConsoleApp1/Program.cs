using System;
using System.IO;

namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DelPath();
           // CreatePath();
            ViewCatalog();
            GetCatalogs();
            // получим системные диски
            DriveInfo[] drives = DriveInfo.GetDrives();
            // Пробежимся по дискам и выведем их свойства
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем: {drive.TotalSize}");
                    Console.WriteLine($"Свободно: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка: {drive.VolumeLabel}");
                }
            }
        }

        static void GetCatalogs()
        {
            string dirName = @"C:\\"; // Прописываем путь к корневой директории MacOS (для Windows скорее всего тут будет "C:\\")
            if (Directory.Exists(dirName)) // Проверим, что директория существует
            {
                Console.WriteLine("Папки:");
                string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога

                foreach (string d in dirs) // Выведем их все
                    Console.WriteLine(d);

                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);// Получим все файлы корневого каталога

                foreach (string s in files)   // Выведем их все
                    Console.WriteLine(s);
            }
        }
        static void ViewCatalog()
        {
            try
            {
                DirectoryInfo viewpath = new DirectoryInfo(@"C:\\");
                if (viewpath.Exists)
                {
                    Console.WriteLine(viewpath.GetDirectories().Length);
                    Console.WriteLine(viewpath.GetFiles().Length);
                }
                DirectoryInfo newdirect = new DirectoryInfo(@"c:\54321");
                if (!newdirect.Exists)
                newdirect.Create();
                Console.WriteLine(viewpath.GetDirectories().Length);
                Console.WriteLine(viewpath.GetFiles().Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        static void DelPath()
        {
            try
            {
                DirectoryInfo delpth = new DirectoryInfo(@"C:\User\sourse\");
                delpth.Delete(true);
                Console.WriteLine("Path delete");
            }
             catch(Exception ex) { Console.WriteLine(ex.Message); }

        }
        static void CreatePath()
        {
            DirectoryInfo crpth = new DirectoryInfo(@"c:\User\sourse\");
            if (!crpth.Exists)
            {
                crpth.Create();
                crpth.CreateSubdirectory("1234567");
                Console.WriteLine(crpth.GetDirectories().Length);
            }
        }
    }
    

    public class Drive
    {
        public string Name { get; }
        public long TotalSpace { get; }
        public long FreeSpace { get; }

        public Drive(string name, long totalSpace, long freeSpace)
        {
            Name = name;
            TotalSpace = totalSpace;
            FreeSpace = freeSpace;
        }
        
        Dictionary<string, Folder> Folders = new Dictionary<string, Folder>();

        public void CreateFolder(string name)
        {
            Folders.Add(name, new Folder());
        }

    }
    public class Folder
    {
        public List<string> Files { get; set; } = new List<string>();
        
    }
    
}


