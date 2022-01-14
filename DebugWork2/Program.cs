using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

class BinaryExperiment
{
    [Serializable]
    public class Student
    {
        public string Name;
        public string Group;
        DateTime DateOfBirth;

        public Student(string name, string group, DateTime dat)
        {
            Name = name;
            Group = group;
            DateOfBirth = dat;
        }
    }

    static void Main()
    {


        //string SetFileNew = @"C:\Users\User\Desktop\BinaryFile.bin";
        string Stud = @"C:\Users\User\Desktop\Students.dat";
        ReadValues(Stud);
        //ReadBin(SetFileNew);
        // Пишем
        string Stud1 = @"C:\Users\User\Desktop\Students1.dat";
        WriteValues(Stud1);
        // Считываем

    }

    static void WriteValues(string Stud1)
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


}



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
