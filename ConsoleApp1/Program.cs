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
        public string Type ;
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
        public string Ar ;
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
       
        public string  GetColor()
        {
            
        }
    }
    
}





