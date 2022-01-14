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
          
            foreach (DriveInfo drive in drives.Where(d => d.DriveType == DriveType.Fixed))// отсортировали из массива дисков только разделы ХДД
            {
                WriteDriveInfo(drive);// вывод разделов ХДД
                DirectoryInfo root = drive.RootDirectory; // получаем корневую папку
                DirectoryInfo[] folders = root.GetDirectories(); // получаем массив каталогов из корневой ппки 
                WriteFoldersInfo(folders); // Передаем массив каталогов в метод подсчета общего размера всех файлов в них

                WriteFilesInfo(root);// передача корневой папки в метод посчета размера файлов в ней
                Console.WriteLine();
                Console.WriteLine();
            }

        } 

        //----------------------- Получение всех Разделов HDD ----------------------
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

        //--------------------- Подсчет размера всех файлов во всех подпапках ----------------------------
        public static void WriteFoldersInfo(DirectoryInfo[] folders)
        {
            Console.WriteLine("Папки");
            Console.WriteLine();
            
            foreach(DirectoryInfo folder in folders)
            {
                try
                {
                    Console.WriteLine(folder.Name + $"{NewProcess.DirSize(folder)}");// 
                }
                catch (Exception ex) { Console.WriteLine(folder.Name + $" Не удалось посчитать размер : {ex.Message} "); }

            }
        }

        // ------------------------- Подсчет файлов и их размер в корневой директории ------------------
        public static void WriteFilesInfo(DirectoryInfo file)
        {
            long size = 0;
            Console.WriteLine("Файлы");
            Console.WriteLine();
            foreach (FileInfo fil in file.GetFiles())
            {
                Console.WriteLine(fil.Name + fil.Length);
                Console.WriteLine("Общий размер файлов :");
                size += fil.Length;
            }
            Console.WriteLine(size);
        }
    }
    




    
    
}




