using System;
using System.IO;

namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
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


