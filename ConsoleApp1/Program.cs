using System;
using System.IO;
using System.Linq;

namespace FirstApp
{
    
    class Program
    {
        static void Main(string[] args)
        {
            
            string dirname = @"C:\User";
            if (Directory.Exists(dirname))
            {
                Console.WriteLine($"Папка доступна {dirname} "); 
            }
            else
            {
                Directory.CreateDirectory(dirname);
            }
            
            FolderExicute.Checkfolder(dirname);

            CountFolder.SizeFolders(dirname);

        }
        public static class FolderExicute
        {
            public static void Checkfolder(string pathname)
            {
                if (Directory.Exists(pathname))
                {
                    Console.WriteLine("Пеершли к Чек Фаилс");
                    CheckFiles(pathname);
                    string [] dirpath = Directory.GetDirectories(pathname);
                    foreach (string dir in dirpath)
                    {
                        Checkfolder(dir);
                    }
                }
                else
                {
                    Console.WriteLine("Кончились папки");
                }
            }
            public static void CheckFiles(string pathname)
            {
                if (!Directory.Exists(pathname))
                {
                    string[] namepath = Directory.GetFiles(pathname);
                    if (namepath.Length != 0)
                        foreach (string v in namepath)
                        {
                            DateTime lastaccess = File.GetLastAccessTime(v);
                            TimeSpan unused = DateTime.Now.Subtract(lastaccess);
                            Console.Write(v);
                            //if (unused > TimeSpan.FromMinutes(30))


                            //TimeSpan interval = TimeSpan.FromMinutes(30);
                            //DateTime dt = File.GetCreationTime(v);
                            //DateTime time = DateTime.Now;
                            try
                            {
                                    if (unused > TimeSpan.FromMinutes(30))
                                    {
                                    Console.WriteLine("Время вышло");
                                    File.Delete(v);
                                }
                                else
                                {
                                    Console.WriteLine("Время не пришло ");
                                }
                            }
                            catch(Exception e)
                            { Console.WriteLine(e.Message); }
                        }
                }
                
            } 
        }
        public static class CountFolder
        {
            public static void SizeFolders(string dirname)
            {

            }
        }
    }
  
}




