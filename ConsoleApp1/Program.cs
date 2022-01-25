using System;
using System.Collections.Generic;
namespace DebugWork1
{


    class Program
    {
        static ILogger logger { get;  set; }
        public static void Main(string[] args)
        {
           logger = new Logger();
           CalculateP calcp = new CalculateP(logger);
           CalculateM calcm = new CalculateM(logger);
           
            try
            {
                switch ()
                {
                    case 
                }
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
            catch (FormatException ex)
            {
                logger.Error(ex.Message);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine(" Вы ввели корректные значения , тем самым не вызвал исключения формата данных! ");
            }
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
