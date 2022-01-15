using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FinalTask
{
    class Program
    {
        [Serializable]
        public class Student
        {
            public string Name { get; set; }
            public string Group { get; set; }
            public DateTime DateOfBirth { get; set; }
            public Student(string name, string group, DateTime dat)
            {
                Name = name;
                Group = group;
                DateOfBirth = dat;
            }
        }
       

        static void Main()
        {
            List <string> group = new List<string>();
            Student[] student = new Student[3];
            student[0] = new Student("Dima", "one", new DateTime(1987,03,02));
            student[1] = new Student("Igor", "two", new DateTime(1988, 04, 03));
            student[2] = new Student("вася", "three", new DateTime(1989, 05, 03));
            string Stud = @"C:\Users\User\Desktop\MyStudentsForm.dat";
            // Создали папку 
            string filePath = @"C:\Users\User\Desktop\Student";
            DirectoryInfo dirInfo = new DirectoryInfo(filePath);
            if (!dirInfo.Exists)
                dirInfo.Create();

            try
            {
                //создаем форматтер 
                BinaryFormatter formatter = new BinaryFormatter();
                //открываем поток 
                using (FileStream fs = new FileStream(@"C:\Users\User\Desktop\MyStudentsForm.dat", FileMode.OpenOrCreate))
                {
                   // сериализация файла 
                    formatter.Serialize(fs, student);
                    Console.WriteLine("File Serialized ");
                    Console.WriteLine("--------------------------------------------------------");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            
            //---------Рабочий Вариант Десериализации и чтения из файла в консоль -----------
            if (File.Exists(Stud))
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (FileStream fs = new FileStream(Stud, FileMode.Open,FileAccess.Read))
                    {
                        List<string> Grouplist = new List<string>();

                        Student[] nstudent = (Student[])bf.Deserialize(fs);
                        Console.WriteLine("Прошла Десериализация");
                        Console.WriteLine("--------------------------------------------------------");
                        Console.WriteLine(" Считали  :");
                        foreach (Student stud in nstudent)
                        {
                           
                            //получили данные 
                            string NewPath = Path.Combine(filePath, stud.Group + ".txt");//имя файла
                            if (!File.Exists(NewPath))
                            {
                                Console.WriteLine($"Создадим файл {NewPath}");
                            }
                            else if (!Grouplist.Contains(stud.Group))
                            {
                                File.Delete(NewPath);   
                            }
                            FileInfo fileInfo = new FileInfo(NewPath);
                            try
                            {
                                using(StreamWriter fss = fileInfo.AppendText())
                                {
                                    fss.Write(stud.Name + "___");
                                    fss.Write(stud.DateOfBirth.ToString("D"));
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            if (!Grouplist.Contains(stud.Group))
                            {
                               Grouplist.Add(stud.Name);
                            }
                           
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine($"{Stud} - Ненайден");
            }

           
        }
        

    }
}

/*//Внутри раскидать всех студентов из файла по группам (каждая группа-отдельный текстовый файл),
//в файле группы студенты перечислены построчно в формате "Имя, дата рождения".
Console.WriteLine("Создаем массив Групп  :");
Groups[] gp = new Groups[student.Length];

foreach (Student stud in student)
{
    for (int i = 0; i < student.Length; i++)
    {
        gp[i] = new Groups(stud.Name, stud.DateOfBirth.ToString("D"));

    }
}

using (StreamWriter sw = File.CreateText(@"C:\Users\User\Desktop\Student\MyStudentsForm.txt"))
{
    Console.WriteLine(stud.Name);
    Console.WriteLine(stud.Group);
    Console.WriteLine(stud.DateOfBirth.ToString("D"));
    *//* Console.WriteLine(stud.Name);
     Console.WriteLine(stud.Group);
     Console.WriteLine(stud.DateOfBirth.ToString("D"));
     sw.WriteLine(stud.Name);
     sw.WriteLine(stud.Group);
     sw.WriteLine();*//*
} 
*/



/* //ReadValues(Stud);
           //ReadBin(SetFileNew);
           // Пишем
           string Stud1 = @"C:\Users\User\Desktop\Students1.dat";
           WriteValues(Stud1);
           // Считываем*/

/* static void WriteValues(string Stud1)
 {
     // Создаем объект BinaryWriter и указываем, куда будет направлен поток данных
     //string stud1 = @"C:\Users\User\Desktop\BinaryFile.bin";
     if (File.Exists(Stud1))
     {
         // FileStream fs = new FileStream()
         using (BinaryWriter writer = new BinaryWriter(File.Open(Stud1, FileMode.Append)))
         {
             // записываем данные в разном формате
             // writer.Write();

         }
     }

 }


 public static void ReadValues(string Stud)
 {

     string Name;
     string Group;
     string DateOfbirth;
     Student student = new Student(Name, Group, DateTime);
     if (File.Exists(Stud))
     {
         using (FileStream fs = new FileStream(Stud, FileMode.Open))
         // using (var stream = File.Open(Stud, FileMode.Open))//, FileAccess.Read))
         {
             var newstu =
                  using (BinaryReader reader = new BinaryReader(fs, Encoding.Default))
             // using (BinaryReader reader = new BinaryReader(stream, Encoding.UTF8 ))
             {
                 Name = reader.ReadString();
                 Group = reader.ReadString();
                 DateOfbirth = reader.ReadString();
             }
             Console.WriteLine("Из файла считано:");
             Console.WriteLine($"Строка:{Name} , {Group}, {DateOfbirth} ");
         }

     }

 }
*/
/* static void ReadBin(string SetFileNew)
{

 //string SetFileNew = @"C:\Users\User\Desktop\BinaryFile.bin";
 if (File.Exists(SetFileNew))
 {
     string Name;
     string Group;
     string DateOfbirth;

     using (BinaryReader reader = new BinaryReader(File.Open(SetFileNew, FileMode.Open)))
     {
         Name = reader.ReadString();
         Group = reader.ReadString();
         DateOfbirth = reader.ReadString();
     }
     Console.WriteLine(Name);
 }


}
}*/

//---------------------- Рабочий вариант Записи Бинарника--------------------------
//создаем врайтер и записываем им данные студента в файл
/*
using (BinaryWriter bw = new BinaryWriter(File.Open(Stud, FileMode.OpenOrCreate)))
                {
                    foreach (Student st in student)
                    {
                        
                        bw.Write(st.Name);
                        bw.Write(st.Group);
                        bw.Write(st.DateOfBirth.ToString("D"));
                    }
                }

//---------Рабочий Вариант Десериализации и чтения из файла в консоль -----------
if (File.Exists(Stud))
{
    try
    {
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream reader = new FileStream(Stud, FileMode.Open, FileAccess.Read))
        {
            Student[] nstudent = (Student[])bf.Deserialize(reader);
            Console.WriteLine(" Считали  :");
            foreach (Student stud in nstudent)
            {
                Console.WriteLine(stud.Name);
                Console.WriteLine(stud.Group);
                Console.WriteLine(stud.DateOfBirth.ToString("D"));
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
else
{
    Console.WriteLine($"{Stud} - Ненайден");
}
//-------------------------------------------------------------------------------------*/