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


	class Rectangle
    {
		public int a;
		public int b;
		public int Square()
        {
			return a * b;
        }

		public Rectangle()
        {
			a = 6;
			b = 4;
        }
		public Rectangle(int side)
		{
			a = side;
			b = side;
		}
		public Rectangle(int first, int second)
		{
			a=first;
			b=second;
		}

	}
	class Human
	{
		// Поля класса
		public string name;
		public int age;

		// Метод класса
		public void Greetings()
		{
			Console.WriteLine("Меня зовут {0}, мне {1}", name, age);
		}
		// Конструктор 1
		public Human()
		{
			name = "Неизвестно";
			age = 20;
		}
		// Конструктор 2
		public Human(string n)
		{
			name = n;
			age = 20;
		}
		// Конструктор 3
		public Human(string n, int a)
		{
			name = n;
			age = a;
		}
	}
	
	class Pen
    {
		public string color;
		public int cost;
		
		public Pen()
        {
			color = "Black";
			cost = 100;
        }

		public Pen(string penColor, int penCost)
        {
			color = penColor;
			cost = penCost;
			//penColor = "Yellow";
			//penCost = 200;
        }
		public void Greetings()
		{
			Console.WriteLine("Мой цвет {0}, и число {1}", color, cost);
		}
	}
	struct Animal
	{
		// Поля структуры
		public string type;
		public string name;
		public int age;

		// Метод структуры
		public void Info()
		{
			Console.WriteLine("Это {0} по кличке {1}, ему {2}", type, name, age);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
		
			Human human = new Human();
			human.Greetings();

			human = new Human("Дмитрий");
			human.Greetings();

			human = new Human("Дмитрий", 23);
			human.Greetings();

			Pen pen = new Pen("Yelow", 300);
			pen.Greetings();

			Console.ReadKey();
		}
	}
}