using System;
using System.Collections.Generic;

class Program
{


    static void Main()
    {
        Calc Calc = new Calc();
        Operate operation = Calc.Nothing;
        char c = default;
        char[] signs = new char[] { '+', '-', '/', '*', 'в' };
        Console.WriteLine("Добро пожаловать в программу калькулятор!");
        Console.Write("Введите число: ");
        decimal a = 0;
        decimal b = 0;
        a = a.GetN(decimal.MinValue, decimal.MaxValue);
        bool check = true;
        decimal? result;
        do
        {
            Console.Write("Введите число: ");
            b = b.GetN(decimal.MinValue, decimal.MaxValue);
            Console.Write("Введите операцию (для выхода из программы - 'в'): ");
            c = c.GetC(signs);
            switch (c)
            {
                case '+': { operation = Calc.Add; break; }
                case '-': { operation = Calc.Subtract; break; }
                case '/': { operation = Calc.Divide; break; }
                case '*': { operation = Calc.Multiply; break; }
                case 'в': { check = false; continue; }
            }
            try
            {
                operation -= Calc.Nothing;
                result = operation?.Invoke(a, b);
                Console.WriteLine("{0} {1} {2} = {3}", a, c, b, result);
                a = result ?? a;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Что-ж вы, батенька, на ноль то делите?!");
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }
        }
        while (check);
        Console.ReadKey();
    }

    public delegate decimal Operate(decimal a, decimal b);
    public interface ICalc
    {
        decimal Add(decimal a, decimal b);
        decimal Multiply(decimal a, decimal b);
        decimal Subtract(decimal a, decimal b);
        decimal Divide(decimal a, decimal b);
    }
    class Calc : ICalc
    {
        public decimal Add(decimal a, decimal b) { return a + b; }
        public decimal Multiply(decimal a, decimal b) { return a * b; }
        public decimal Subtract(decimal a, decimal b) { return a - b; }
        public decimal Divide(decimal a, decimal b) { return a / b; }
        public decimal Nothing(decimal a, decimal b) { return 0; }
    }
}


