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
            var calcp = DebugWork1.CalculateP(logger);
            var calcm =
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
                //Console.BackgroundColor = ConsoleColor.Red;

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
            Console.WriteLine(message);
        }

        public void Event(string message)
        {
            Console.WriteLine(message); 
        }
    }
    public interface ICalc<T,Z>
    {
        public double Calc(T x, T y);
    }
}
