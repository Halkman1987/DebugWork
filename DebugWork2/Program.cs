using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Serialization
{

    // Описываем наш класс и помечаем его атрибутом для последующей сериализации   
    [Serializable]
    class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Pet(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    [Serializable]
    class Contact
    {
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contact(string name, long phoneNumber, string email)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            var usr = new Contact("dima", 64564564, "spl@mail.ru");
            BinaryFormatter cont = new BinaryFormatter();
            using (var cn = new FileStream("anketa.dat",FileMode.OpenOrCreate))
            {
                cont.Serialize(cn, usr);
                Console.WriteLine("Объект Anketa сериализован");
            }
            
            // объект для сериализации
            var person = new Pet("Rex", 2);
            Console.WriteLine("Объект создан");

            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (var fs = new FileStream("myPets.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, person);
                Console.WriteLine("Объект сериализован");
            }
            // десериализация
            using (var fs = new FileStream("myPets.dat", FileMode.OpenOrCreate))
            {
                var newPet = (Pet)formatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Имя: {newPet.Name} --- Возраст: {newPet.Age}");
            }
            Console.ReadLine();
        }
    }

    public class Drive
    {
        public Drive(string name, long totalSpace, long freeSpace)
        {
            Name = name;
            TotalSpace = totalSpace;
            FreeSpace = freeSpace;
        }

        public string Name { get; }
        public long TotalSpace { get; }
        public long FreeSpace { get; }





        
        Dictionary<string, Folder> Folders = new Dictionary<string, Folder>();
        
        public void Createfolder(string name)
        {
            Folders.Add(name, new Folder());
        }
        
        //-----------------------------------------------------------
        public Folder folder { get; } // Создание папки напрямую 
        public void createfiles(string name) 
        {
            folder.Files.Add(name);
        }
    }


    public class Folder
    {
        public List<string> Files { get; set; } = new List<string>();
    }
}
