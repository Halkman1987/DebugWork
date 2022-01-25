using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FinalTask
{
    class Program
    {
        public interface ICalc<T, Z>
        {
            double Calc(T x, T y);
        }
        public class CalculateP : ICalc<double, double>
        {
            public double Calc(double x, double y)
            {
               return x + y;
            }
        }
        public class CalculateM : ICalc<double, double>
        {
            public double Calc(double x, double y)
            {
                return x - y;
            }
        }
        static void Main()
        {
            
            ICalc<double, double> calc = new CalculateP();
            ICalc<double,double> calc2 = new CalculateM();
            try
            {
                Console.WriteLine("Введите первое число : ");
                double x = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите второе число : ");
                double y = Convert.ToDouble(Console.ReadLine());
                var resultp = calc.Calc(x, y);
                var resultm = calc2.Calc(x, y);
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine();
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Результатом сложения является чиcло : {resultp}");
                
                Console.ResetColor();
               
               
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Результатом вычитания является чиcло : {resultm}");
                Console.ResetColor();
                

            }
            catch (FormatException ex)
            {
                Console.WriteLine(" Вы ввели некорректные значения ");
                Console.WriteLine(ex.Message);

            }
            finally
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine(" Вы ввели корректные значения , тем самым не вызвал исключения формата данных! ");
                Console.ResetColor();
            }
            
            /*IMessenger<Phone> viberInPhone = new Viber<Phone>();
            IMessenger<IPhone> viberInIPhone = new Viber<IPhone>();

            viberInPhone.DeviceInfo();
            viberInIPhone.DeviceInfo();*/
            IMessenger<Phone> viberInPhone = new Viber<Phone>();
            viberInPhone.DeviceInfo();

            IMessenger<IPhone> viberInIphone = new Viber<IPhone>();
            viberInIphone.DeviceInfo();

            IUpdater<Account> updater = new UserService();
            IUpdater<User> updater1 = new UserService();
        }

    }
    public class User { }
    public class Account: User { }
    public interface IUpdater<in T>
    {
        void Update(T entity);

    }
    public class UserService : IUpdater<User>
    {
        public void Update(User entity)
        {
            //throw new NotImplementedException();
        }
    }




    public interface IMessenger<T>
    {
        T DeviceInfo();
    }
    public class IPhone : Phone { }
    public class Phone { }
    public class Computer { }

    public class Viber<T> : IMessenger<T> where T : Phone, new()
    {
        public T DeviceInfo()
        {
            T device = new T();
            Console.WriteLine(device);
            return new T();
        }
    }
   

}

