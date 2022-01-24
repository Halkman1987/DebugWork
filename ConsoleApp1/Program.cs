﻿using System;
using System.Collections.Generic;

class Program
{
    public class MyExciption : Exception
    {
        public MyExciption() : base("Зачем вы ввели не заданные числа???")
        {
           
        }
    }
    public class SortList
    {
        public delegate string[] SortFamDel(string[] a);
        public event SortFamDel SortFamEvent;
        public void Read()
        {
            Console.WriteLine("Введите число 1 или 2");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num != 1 && num != 2) throw new FormatException();
            Sorted(num);
        }
        public string[] NumberEnter(string[] a)
        {
            return SortFamEvent(a);
        }
    }
   
    public static void Main(string[] args)
    {
        List<string> Family = new List<string>();
        Family.Add("Гринн");
        Family.Add("Огородников");
        Family.Add("Шварцнеггер");
        Family.Add("Коломбо");
        Family.Add("Прист");
        Family.Add("Катллер");
        
        SortList sortList = new SortList();
        SortList.SortFamDel sortFamDel = new SortList.SortFamDel();
        sortList.SortFamEvent += Sorted;

        sortList.Read();

        int choice = Convert.ToInt32(Console.ReadLine());
        try
        {
            sortList.Read();
        }
        catch (MyExciption ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Зачем вы ввели не заданные числа???");
        }
        catch (FormatException e) { Console.WriteLine(e.Message); }
        //-------------------------------------------------------------------------------------------------------------
        Exception[] exc = { new FormatException("Это сработало Формат Эксэпшн"), new ArgumentNullException(), new MyExciption(), new RankException("Опять этот РанкЭксэпшн"), new TimeoutException() };
        foreach (Exception ex in exc)
        {
            try
            {
                throw ex;
            }
            catch (MyExciption ex0)
            {
                Console.WriteLine(ex0.Message);
            }
            catch (FormatException ex1)
            {
                Console.WriteLine(ex1.Message);
            }
            catch (ArgumentNullException ex2)
            {
                Console.WriteLine(ex2.Message);
            }
            catch (TimeoutException ex3)
            {
                Console.WriteLine(ex3.Data.Values);
            }
            catch (RankException ex4)
            {
                Console.WriteLine(ex4.GetType());
                Console.WriteLine(ex4.Message);
            }
        }
        //-------------------------------------------------------------------------------------------------------------       

    }

}


