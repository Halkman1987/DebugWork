using System;
using System.IO;

namespace FirstApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            
            

            var filePath2 = new FileInfo( @"D:\Source\Repos\TestWork\ConsoleApp1\ConsoleApp1\Program.cs");
            
            DateTime now = DateTime.Now;
            using (StreamWriter sw = filePath2.AppendText())
            {
                sw.WriteLine($"// Время запуска \n {now}");// Добавили в конец файла вывод даты текущей 
            }
            
            using (StreamReader sr = filePath2.OpenText())// выводим на консоль содержание файла Program.cs с добавленной записью ($"// Время запуска \n {now}")
            {
                string str = "";
                while ((str = sr.ReadLine()) != null)
                {
                    Console.WriteLine(str);
                }
            }

            // Создание временного имени файла1
            string tempFile = Path.GetTempFileName();
            var fileInfo = new FileInfo(tempFile);//Создание объекта класса и присвоении ему временного имени файла1

            using (StreamWriter sw = fileInfo.CreateText()) // Запись в бинарном формате
            {
                sw.WriteLine("Дима");
                sw.WriteLine("Учиться");
                sw.WriteLine("Кодить");
            }
            using (StreamReader sr = fileInfo.OpenText())
            {
                string ln = "";
                while ((ln = sr.ReadLine()) != null)
                {
                    Console.WriteLine(ln);
                }
            }
            try
            {
                // Создание временного имени файла2
                string tempFile2 = Path.GetTempFileName();
                var fileInfo2 = new FileInfo(tempFile2);
                fileInfo2.Delete();

                fileInfo.CopyTo(tempFile2);
                Console.WriteLine($"{tempFile} скопирован в файл {tempFile2}");

                fileInfo.Delete();
                Console.WriteLine($"{tempFile} Удален");

                StreamWriter newtxt = fileInfo2.AppendText();

                newtxt.WriteLine(now);

            }
            catch (Exception ex) { Console.WriteLine($" Ошибка {ex}"); }


            // -- создание текстового файла с содержимым --
            string filePath = @"C:\User\skp.txt";
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine("dima");
                    sw.WriteLine("Учиться");
                    sw.WriteLine("Кодить");
                }
            }
            //-----------------------------------------------
           
            DelPath();
            CreatePath();
            ViewCatalog();
            GetCatalogs();
            CreateAndDelete();

            // --------------------  РАБОТА С ДИСКАМИ получим системные диски --------------------------------------
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
            //-----------------------------------------------------------------------------------------------------------
        }
        // -------------------------------- Получение Всех каталогов и Всех папок из нужного каталога -------------------------------------
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
        // ------------------------- Подсчет Колличества Папок и Фалов в Нужной директории --------------------------
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
        //--------------------------------------------------------------------------------------------------------------
        
        // ----------------------------- Удаление ВСЕГО содержимого Каталога -----------------------
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
        //------------------------------------------------------------------------------------------
       
        // ---------------- Создание Папи и перемещение её в другую -------------------
        static void CreateAndDelete()
        {
            DirectoryInfo crt = new DirectoryInfo(@"C:\Users\User\Desktop\1testFolder");
            if (!crt.Exists)
            {
                crt.Create();
            }
            try
            {
                DirectoryInfo nfld = new DirectoryInfo(@"C:\Users\User\Desktop\1testFolder");
                string trashPath = @"C:\$Recycle.Bin";   //C:\User\1testFolder
                //Directory.Move(crt, trashPath);
                nfld.MoveTo(trashPath);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        //----------------------------------------------------------------------------

        // ---------------------------------- Создание Каталога с вложенным подкаталогом ------------------------------
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
        //-------------------------------------------------------------------------------------------------------------
    }
    




    //-----------------------------------------------------------------------------------------------------------------------------------------------------
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



