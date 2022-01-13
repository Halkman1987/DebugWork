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


            //------------------ 8.6.4 -Бинарное счтение из файла и копирование по трем файлам --------------------------------
            string newdir = @"C:\Users\User\Desktop\Students";
            CreateDir.CreateDr(newdir); //Создали директорию в методе 
            string Studdat = @"C:\Users\User\Desktop\Students.dat";
            BinaryRead.BinRead(Studdat);// Передали на считтывание файл 

            //------------------ 8.6.4. ---- Конец ----------------------------------------------------------------------------
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
        
        // ----------------------------- Задание 4 --------------------------------
        public static class CreateDir
        {
            public static void CreateDr(string dirname)
            {
                try
                {
                    if (Directory.Exists(dirname))
                    {
                        Directory.CreateDirectory(dirname);
                    }
                }
               catch (Exception e) { Console.WriteLine(e.Message); }
            }
        }
        public static class BinaryRead
        {
            public static void BinRead(string file)
            {
               
                string Name;
                string Group;
                DateTime DateOfBirth;
                
                if (File.Exists(file))
                {
                    // Создаем объект BinaryReader и инициализируем его возвратом метода File.Open.
                    using (BinaryReader reader = new BinaryReader(File.Open(file, FileMode.Open)))
                    {
                        // Применяем специализированные методы Read для считывания соответствующего типа данных.
                       
                        Name = reader.ReadString();
                        Group = reader.ReadString();
                        DateOfBirth = reader.ReadString();
                    }

                    Console.WriteLine("Из файла считано:");

                    
                    Console.WriteLine("Строка: " + Name);
                    Console.WriteLine("Строка: " + Group);
                }
            }
        }
    }
  
}




