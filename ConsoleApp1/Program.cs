using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace DebugWork1
{


    class Program
    {
        public class Contact // модель класса
        {
            public Contact(long phoneNumber, string email)
            {
                PhoneNumber = phoneNumber;
                Email = email;
            }

            public Contact(string name, string lastName, long phoneNumber, string email) // метод-конструктор
            {
                Name = name;
                LastName = lastName;
                PhoneNumber = phoneNumber;
                Email = email;
            }

            public string Name { get; }
            public string LastName { get; }
            public long PhoneNumber { get; }
            public string Email { get; }
        }

        List<string> lines = File.ReadAllLines("test.txt").ToList();
        public static void WriteAllContacts()
        {
            foreach (var contact in PhoneBook)
                Console.WriteLine(contact.Key + ": " + contact.Value.PhoneNumber);
            Console.WriteLine();
        }
        private static Dictionary<string, Contact> PhoneBook = new Dictionary<String, Contact>()
        {
            ["Игорь"] = new Contact(79990000000, "igor@example.com"),
            ["Андрей"] = new Contact(79990000001, "andrew@example.com"),
        };
        static ILogger logger { get;  set; }
       
        public static void Main(string[] args)
        {
            var phoneBook = new List<Contact>();
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            while (true)
            {
                var keyChar = Console.ReadKey().KeyChar;
                var pars = Int32.TryParse(keyChar.ToString(), out int keyP);
                if(!pars || keyP <1 || keyP > 3)
                {
                    Console.WriteLine("No page");
                }
                else
                {
                    var pagE = phoneBook.Skip((keyP-1)*2).Take(2);
                    Console.WriteLine();
                    foreach(var par in pagE)
                        Console.WriteLine(par.Name+" "+par.LastName+" "+par.PhoneNumber);
                }
            }
//------------------------------------------------------------------------------------------------------------------
            string text = File.ReadAllText("C:\\Users\\User\\Desktop\\Text1.txt");
            foreach (var w in text)
                Console.WriteLine(w);
                Console.WriteLine("Текущий список контактов: ");
            WriteAllContacts();

            // Попробуем добавить новый контакт, если такого ещё нет
            PhoneBook.TryAdd("Диана", new Contact(79160000002, "diana@example.com"));

            //  Выведем обновлённый список
            Console.WriteLine("Обновленный список контактов: ");
            WriteAllContacts();

            //  Попробуем достать контакт для изменения данных
            if (PhoneBook.TryGetValue("Диана", out Contact contact))
                contact.PhoneNumber = 79990000001;

            // И покажем результат после изменения
            Console.WriteLine("Список после изменения: ");
            WriteAllContacts();


            // Создаем сортированный словарь
            SortedDictionary<string, int> sortedDictionary = new SortedDictionary<string, int>();
            // Добавим несколько элементов в случайном порядке
            sortedDictionary.Add("zebra", 5);
            sortedDictionary.Add("cat", 2);
            sortedDictionary.Add("dog", 9);
            sortedDictionary.Add("mouse", 4);
            sortedDictionary.Add("programmer", 100);
            // Ищем собаку
            if (sortedDictionary.ContainsKey("dog"))
                Console.WriteLine("Нашли собаку");
            // Ищем зебру
            if (sortedDictionary.ContainsKey("zebra"))
                Console.WriteLine("Нашли зебру");
            // Ищем обезьяну
            if (sortedDictionary.ContainsKey("ape"))
                Console.WriteLine("Нашли обезьяну");

            Console.WriteLine();

            // Теперь посмотрим, кто у нас живёт и в каком порядке
            Console.WriteLine("Посмотрим всех:");

            foreach (KeyValuePair<string, int> p in sortedDictionary)
                Console.WriteLine($"{p.Key} = {p.Value}");
            // запускаем новый таймер
            var stopWatch = Stopwatch.StartNew();

            // выполняем операцию
            var result = 50063 / 834;

            // смотрим, сколько операция заняла, в миллисекундах
            Console.WriteLine(stopWatch.Elapsed.TotalMilliseconds);






            logger = new Logger();
           CalculateP calcp = new CalculateP(logger);
           CalculateM calcm = new CalculateM(logger);
           
            
               
                Console.WriteLine("Введите первое число : ");
                double x = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите второе число : ");
                double y = Convert.ToDouble(Console.ReadLine());
                var resultp = calcp.Calc(x, y);
                var resultm = calcm.Calc(x, y);
                Console.WriteLine();
                Console.WriteLine($"Результатом сложения является чиcло : {resultp}");
                Console.WriteLine($"Результатом вычитания является чиcло : {resultm}");
              
            
           
        }

    }
    public interface ILogger
    {
        void Event(string message);
        void Error(string message);
    }
    public class Logger : ILogger
    {
        public void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void Event(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
    public interface ICalc<T,Z>
    {
        public double Calc(T x, T y);
    }
}
