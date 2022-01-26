using System;
using System.Collections.Generic;
namespace DebugWork1
{


    class Program
    {
        static ILogger logger { get; set; }
        public static void Main(string[] args)
        {
            logger = new Logger();
            CalculateP calcp = new CalculateP(logger);
            CalculateM calcm = new CalculateM(logger);
            Console.WriteLine("Добро пожаловать в примитивный калькулятор!");
            string choice = null;
            try
            {
                do
                {
                    Console.WriteLine("Введите первое число : ");
                    double x = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите второе число : ");
                    double y = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Выберите операцию + или - :");
                    choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "+":
                            double resp = calcp.Calc(x, y);
                            Console.WriteLine($"Результатом сложения является чиcло : {resp}");
                            break;
                        case "-":
                            double resm = calcm.Calc(x, y);
                            Console.WriteLine($"Результатом вычитания является чиcло : {resm}");
                            break;
                        default:
                            Console.WriteLine("Давайте еще раз введем цифры и всётаки выберем операцию + или - !!!");
                            break;
                    }
                }
                while (choice != "+" && choice != "-" );
            }
            catch (FormatException ex) {logger.Error(ex.Message);}
            catch (Exception e) { logger.Error(e.Message);}
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
    public interface ICalc<T, Z>
    {
        public double Calc(T x, T y);
    }
}
