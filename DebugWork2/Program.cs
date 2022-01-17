using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FinalTask
{
    class Program
    {

        static void Main()
        {
           string[] PickAdr = { "1) Первая точка какойто город1 улица1 и дом1", "\n 2) Вторая точка какойто город2 улица2 и дом2" };
            Console.WriteLine($"  {PickAdr[0]} --- {PickAdr[1]} " );
            Console.WriteLine("-----------------------------");
            /* foreach(string Pick in PickAdr)
             {
                 Console.WriteLine(Pick);
             }*/
            Console.WriteLine("Введите номер постамата ");
            int ii = Convert.ToInt32(Console.ReadLine());
            ViewPick(ii);
            
            
            void ViewPick(int i)
            {
                Console.WriteLine(" Вы выбрали данный постамат : ");
                Console.WriteLine($" {PickAdr[i -1]} ");
            }
        }


    }
    

}

