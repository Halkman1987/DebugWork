using System;
using System.IO;
using System.Linq;
namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
           // string local = @"D:\Source";
           //
            foreach (DriveInfo drive in drives.Where(d => d.DriveType == DriveType.Fixed))
            {
                WriteDriveInfo(drive);
                DirectoryInfo root = drive.RootDirectory;
                DirectoryInfo[] folders = root.GetDirectories();
                WriteFoldersInfo(folders);
                
                Console.WriteLine();
                Console.WriteLine();
            }

        } 
        public static void WriteDriveInfo(DriveInfo drive)
        {
            Console.WriteLine(drive.Name);
            Console.WriteLine(drive.DriveType);
            if (drive.IsReady)
            {
                Console.WriteLine($"{drive.TotalSize}");
                Console.WriteLine($"{drive.TotalFreeSpace}");
                Console.WriteLine($"{drive.VolumeLabel}");
            }
        }
        public static void WriteFoldersInfo(DirectoryInfo[] folders)
        {
            Console.WriteLine("Папки");
            Console.WriteLine();
            
            foreach(DirectoryInfo folder in folders)
            {
                Console.WriteLine(folder);
            }
        }
    }
    




    
    
}




