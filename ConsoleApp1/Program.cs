using System;

namespace FirstApp
{
    class Company
    {
        public string Type;
        public string Name;
    }

    class Department
    {
        public Company Company;
        public City City;

    }

    class City
    {
        public string Name;
    }

    class Program
    {


        static void Main(string[] args)
        {
            TrafficLight trafficLight = new TrafficLight();
            trafficLight.Agge = 34;

            Office office = new Office();


            if (office.Otdel.Type == "ГИП" && office.Comp.Ar == "Power")
            {
                Console.WriteLine("В отделе {0} на {1} этаже ", office?.Otdel?.Rang ?? "Главный архитектор", office?.Otdel?.Etag);
            }
            else
            {
                Console.WriteLine("Fuck you");
            }
            // var department = GetCurrentDepartment();
        }
    }

    /*  static Department GetCurrentDepartment()

      {

          Department department = new Department();


          *//*if (department?.Company?.Type == "Банк" && department?.City?.Name == "Санкт-Петербург")
          {
              Console.WriteLine("У банка {0} есть отделение в Санкт-Петербурге", department?.Company?.Name ?? "Неизвестная компания");
          }*//*
          else
          {
              Console.WriteLine("Fuck you");
          }
          return department;
      }

      class Bus
      {
          public int? Value;

          public void PrintStatus()
          {
              if (Value.HasValue)
              {
                  Console.WriteLine("В автобусе {0] пассажиров", Value);
              }
              else
              {
                  Console.WriteLine("Автобус пуст");
              }
          }

      }
  */
    class Otdel
    {
        public string Type;
        public string Rang;
        public int Etag;
    }

    class Office
    {
        public Otdel Otdel;
        public Comp Comp;
    }

    class Comp
    {
        public string Ar;
        public string Sm;
    }

    class TrafficLight
    {

        private int agge;
        public int Agge
        {
            get { return agge; }
            set { agge = value; }
        }
        private void ChangeColor(string color)
        {

        }

        public string GetColor()
        {

        }
    }

    /// <summary>
    /// ---------------------- Задание 6.6.2 -------------------
    /// </summary>
    class User
    {
        private string login;
        private string Login
        {
            get
            {
                return login;
            }
            set
            {
                if (value.Length < 3)
                {
                    Console.WriteLine("Вы ввели недостаточную длину логина ");
                }
                else
                {
                    login = value;
                }
            }
        }
        private string post;
        public string Post
        {
            get
            {
                return post;
            }
            set
            {

                if (!value.Contains('@'))
                {
                    Console.WriteLine("Вы не ввели символ @ ");
                }
                else
                {
                    post = value;
                }
            }
        }



    }

     class Triangle
    {
        private int Aa;
        private int Bb;
        private int Cc;

        public int aa
        {
            get { return Aa; }
            set 
            {
                if (value > 0 && Bb + Cc > value)
                {
                    Aa = value;
                }
               
            }
        }
        public int bb
        {
            get { return Bb; }
            set
            {
                if (value > 0 && Aa + Bb > value)
                {
                    Bb = value;
                }
            }
        }
        public int cc 
        {
            get { return Cc; }
            set
            {
                if ((value > 0) && Aa + Bb > value)
                {
                    Cc = value;
                }
            }
        }
    } 
}





