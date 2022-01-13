using System;
using System.IO;
using System.Linq;

namespace FirstApp
{

    class Program
    {
        static void Main(string[] args)
        {

            /*string dirname = @"C:\User\123";
            if (Directory.Exists(dirname))
            { Console.WriteLine($"Папка доступна {dirname} "); }

            else { Directory.CreateDirectory(dirname); }

            FolderExicute.Checkfolder(dirname);// передали путь @"C:\User"*/
            // ------------ Задание 2 --- Подсчет папки ---------------------
            string dirname2 = @"C:\User\Visual";

            DirectoryInfo root = new DirectoryInfo(dirname2);
            
            CountFolder.SizeFolders(root);
            //CountFolder.SizeFolders(dirname2);
            Console.WriteLine("Вывод размера каталога  : C:-User-Visual ");
            var size = CountFolder.SizeFolders(root);
            Console.WriteLine(size);
            Console.WriteLine();
            Console.WriteLine($"сумма всех файлов и папок :{CountFolder.SizeFolders(root)} ");

            //------------------ 8.6.4 -Бинарное счтение из файла и копирование по трем файлам --------------------------------
           /* string newdir = @"C:\Users\User\Desktop\Students";
            CreateDir.CreateDr(newdir); //Создали директорию в методе 
            string Studdat = @"C:\Users\User\Desktop\Students.dat";
            BinaryRead.BinRead(Studdat);// Передали на считтывание файл */

            //------------------ 8.6.4. ---- Конец ----------------------------------------------------------------------------
        }
        public static class FolderExicute
        {
            public static void Checkfolder(string pathname) // приняли путь
            {
                if (Directory.Exists(pathname)) //Проверили на наличие
                {
                    Console.WriteLine("Пеершли к Чек Фаилс");
                    CheckFiles(pathname);// отдали путь на проверку файлов

                    string[] dirpath = Directory.GetDirectories(pathname);
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

                string[] namepath = Directory.GetFiles(pathname);// получили массив файлов
                                                                
                foreach (var v in namepath)
                {
                    DateTime lastaccess = File.GetLastAccessTime(v);
                    TimeSpan fileacc = DateTime.Now.Subtract(lastaccess);
                    Console.Write(v);
                    if (fileacc > TimeSpan.FromMinutes(30)) // проверили условие
                    {
                        Console.WriteLine("Время вышло");
                       try
                        {
                            File.Delete(v);
                            Console.Write("Файл успешно удален");
                        }
                        catch (Exception ex)
                        {
                            
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Время не пришло ");
                    }
                }
                          
            }


        }
    }
    public static class CountFolder
    {
        public static long SizeFolders(DirectoryInfo dirname)
        {
            //DirectoryInfo[] folders = root.GetDirectories();
            long size = 0;
            FileInfo[] files = dirname.GetFiles();

            foreach (FileInfo f in files)
            {
                size += f.Length;
            }
            DirectoryInfo[] dirs = dirname.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                size += SizeFolders(dir);
            }
            return size;
        }
       /* public static long SizeFolders(string dirname)
        {
            long size = 0;
            string[] files = Directory.GetFiles(dirname);
            
            foreach (string f in files)
            {
                size += f.Length;
            }
            string[] dirs = Directory.GetDirectories(dirname);
            foreach(string dir in dirs)
            {
                size += SizeFolders(dir);
            }
            return size;
        }*/
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
                    //DateOfBirth = reader.ReadString();
                }

                Console.WriteLine("Из файла считано:");


                Console.WriteLine("Строка: " + Name);
                Console.WriteLine("Строка: " + Group);
            }
        }
    }
}
  





