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
            foreach (DriveInfo drive in drives.Where(d :DriveInfo => d.DriveFormat == DriveType.Fixed))
            {
                Console.WriteLine(drive.Name);
                Console.WriteLine(drive.DriveType);
                if (drive.IsReady)
                {
                    Console.WriteLine($"{drive.TotalSize}");
                    Console.WriteLine($"{drive.TotalFreeSpace}");
                    Console.WriteLine($"{drive.VolumeLabel}");
                }
                Console.WriteLine();
                Console.WriteLine();

            }



        }  
    }
    




    
    
}




