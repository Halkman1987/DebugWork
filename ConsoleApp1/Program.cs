using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Prog
{

    class Program
    {
        public delegate void ShowMessageDelegate(string a);
        public delegate int SumDelegate(int a, int b, int c);
        public delegate bool CheckLengthDelegate(string row);

        public delegate void Procedure(int a, int b);


        static void ShowMessage(string a)
        {
            Console.WriteLine(a);
        }
        static int Sum(int a, int b, int c)
        {
            return a + b + c;
        }
        static bool CheckLength(string _row)
        {
            if (_row.Length > 3) return true;
            return false;
        }
        public static void Main(string[] args)
        {
            ShowMessageDelegate showMessageDelegate = ShowMessage;
            showMessageDelegate.Invoke("fgsfghsfghfghfd");

            SumDelegate sumDelegate = Sum;
            int result = sumDelegate.Invoke(4, 7, 1);
            Console.WriteLine(result);

            CheckLengthDelegate checkLengthDelegate = CheckLength;
            bool result1 = checkLengthDelegate.Invoke("Skill_factory");
            Console.WriteLine(result1);
        }

        class MyException : Exception
        {

            public MyException()
            {

            }
            public MyException(string message) : base(message)
            {

            }
        }
        class MyNewException : ArgumentException
        {
            public MyNewException(string? message) : base(message)
            {
            }

            public MyNewException(string? message, Exception? innerException) : base(message, innerException)
            {
            }

            public MyNewException(string? message, string? paramName) : base(message, paramName)
            {
            }

            public MyNewException(string? message, string? paramName, Exception? innerException) : base(message, paramName, innerException)
            {
            }

            protected MyNewException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

        }
    }
}


