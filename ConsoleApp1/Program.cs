using System;

namespace FirstApp
{
    /// <summary>
    /// Запись ссылок в виде переменной между классами 
    /// </summary>
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
        public string Login
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
    // ---------- Опредение треугольника с проверкой его сторон на сумму ------------------------------------
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
    //--------------------------------------------------------------------------------------------------------
    
    class Obj
    {
        //перегрузка операторов + и - 
        public int Value;
        public static Obj operator +(Obj a, Obj b)
        {
            return new Obj
            {
                Value = a.Value + b.Value,
            };
        }
        public static Obj operator - (Obj a, Obj b)
        {
            return new Obj
            {
                Value = a.Value - b.Value,
            };
        }

        private string name;
        private string owner;
        private int length;
        private int count;
        private string description;
        // Это конструктор ( т.к. имеет имя КЛАССА в котором он объявлен. В него из Main нужно будет передать данные , но сначала сделать ссылку на него ( var obj = new Obj("Объект", "Нет описания")
        // И в скобках указать значения которые мы передаем ему ,по количеству переменных)
        public Obj(string name,string ownerName, int objLength, int count)
        {
            this.name = name;
            owner = ownerName;
            length = objLength;
            this.count = count;

        }
        public Obj(string name, string description) : this() 
        {
            this.name = name;
            this.description = description;
        }
        
    }

    // ---------------------- Ввод имени через приватную name и через метод  Greetings(string name) с передачей аргумента заранее вписанного -------------------
    class SmartHelper
    {
        private string Name;
        // тут мы передали "Олег" в name конструктору в Main через SmartHelper helper = new SmartHelper("Олег");
        public SmartHelper(string name)
        {
            this.Name = name;
        }

        // Тут выполнили метод Greetings(string name) котрый принимает в Main  через объявленнкую переменную helper для класса SmartHelper и через точку указывается метод в этом классе который мы вызываем : helper.Greetings("Грег");
        // в методе есть переменная name которой присваивается значение аргумента helper.Greetings("Грег");
        public void Greetings(string name)
        {
            Console.WriteLine("Привет, {0}, я интеллектуальный помощник {1}",name,this.Name );
        }
    }
    class Programm
    {
        static void Main(string[] args)
        {
            SmartHelper helper = new SmartHelper("Олег");
            helper.Greetings("Грег");

            Console.ReadKey();

            //для 
            HomoSapiens hs = new HomoSapiens();
            Human human = hs;
            Creature creature = (Creature)human;
            Creature secondCreature = new Animal();

            DerivedClass obj = new DerivedClass("dFCZ", "dfvfv");
            obj.Display();
        }

    }




    class BaseClass
    {
        public virtual int Counter { get; set; }
        protected string Name;
        public virtual void Display()
        {
            Console.WriteLine("Метод класса BaseClass");
        }
        public BaseClass(string name)
        {
            Name = name;
        }
    }

    class DerivedClass : BaseClass
    {
        public string Description;
        private int counter;
        public override int Counter 
        { 
            get
            {
                return counter;
            }

            set
            {
                if (value >= 0)
                {
                    counter = value;
                }
            }
        }
       
        public override void Display() 
        {
            base.Display();
            Console.WriteLine("Метод класса DerivedClass");
        }

        public  DerivedClass(string name, string description) : base(name)
        {
            
            Description = description;
        }
        public DerivedClass(string name, string description, int counter) : base(name)
        {
            Counter = counter;
            Description = description;

        }
       
    }
    class Creature { }

    class Animal : Creature { }

    class Human : Creature { }

    class HomoSapiens : Human { }


    // ----------------------  7.2.7 ----------------------- 
    class A 
    {
        public virtual void Display()
        {
            Console.WriteLine("A");
        }
    }
    class B : A
    {
        public new void Display()
        {
            Console.WriteLine("B");
        }
    }
    class C : A
    {
        public override void Display()
        {
            Console.WriteLine("C");
        }
    }
    class D : B 
    {
        public new void Display()
        {
            Console.WriteLine("D");
        }
    }
    class E : C 
    {
        public new void Display()
        {
            Console.WriteLine("E");
        }
    }


    class Vector
    {
        public int X;
        public int Y;
        //    Метод с перезагрузкой оператора " + "
        public static Vector operator + (Vector a, Vector b)  //Vector Add(Vector second)
        {
            return new Vector
            {
                X = a.X + b.X,
                Y = a.Y + b.Y
            };
        }
    }
   
    
    class IndexingClass
    {
        private int[] array;

        public IndexingClass(int[] array)
        {
            this.array = array;
        }
        public int this[int index]
        {
            get { return array[index];}
            set { array[index] = value; }
        }
    }
}





