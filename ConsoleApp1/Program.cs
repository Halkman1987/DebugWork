using System;
using System.Collections.Generic;

class Program
{
    class Mypickpoints
    {
        public string adresses;

       public Mypickpoints(string adresses)
        {
            this.adresses = adresses;
        }
    }
    public static void Main(string[] args)
    {
        Mypickpoints[] mypickpoints = new Mypickpoints[2];
        mypickpoints[0] = new Mypickpoints("Какойто адресс 1");
        mypickpoints[1] = new Mypickpoints("Какойто адресс 2");
        /* List<string> Mypickpoints = new List<string>();
        Mypickpoints.Add("какойто адресс 1");
        Mypickpoints.Add("какойто адресс 2");*/
        Korziva korz = new Korziva();
        //Заводим номенклатуру товаров 
        Product[] tov = new Product[11];
        tov[0] = new Product (1 , "Гриф Олимпийский с замками 20кг",  20000 );
        tov[1] = new Product(2 ,"Диск 20кг",  3000);
        tov[2] = new Product(3 ,"Диск 10кг",  2000);
        tov[3] = new Product(4 ,"Диск 5кг",  1000);
        tov[4] = new Product(5 ,"Гиря 32кг",  2500);
        tov[5] = new Product(6 ,"Гиря 24кг",  2000);
        tov[6] = new Product(7 ,"Гиря 16кг",  1500);
        tov[7] = new Product(8 ,"Гантель 5кг", 600);
        tov[8] = new Product(9 ,"Гантель 8кг", 700);
        tov[9] = new Product(10 ,"Гантель 12кг", 800);
        tov[10] = new Product(11 ,"Гантель 16кг", 900);
        //Добавление в Список товаров из класса Продукт
        //
        List<Product> list = new List<Product>();
        list.Add(tov[0]);
        list.Add(tov[1]);
        list.Add(tov[2]);
        list.Add(tov[3]);
        list.Add(tov[4]);
        list.Add(tov[5]);
        list.Add(tov[6]);
        list.Add(tov[7]);
        list.Add(tov[8]);
        list.Add(tov[9]);
        list.Add(tov[10]);
        foreach(var ls in list)// Вывод товаров из массива в консоль
        {
            Console.WriteLine($" {ls.pd} -- {ls.name} = {ls.cash} ");
        }
        
        Console.WriteLine("\tДобро пожаловать в магазин спорт-инвентаря :");
        Console.WriteLine("\tИмеются данные товары :");
        foreach(var p in tov)
        {
            
            Console.WriteLine( $" {p.pd} - {p.name} = {p.cash} рублей");
        }
        Console.WriteLine();

        Console.WriteLine("Выберите товары, введите номер товара :");
        int numtov = Convert.ToInt32(Console.ReadLine());
        Product vibor = tov[numtov];
        Console.WriteLine(" Укажите количество :");
        int muchtov = Convert.ToInt32(Console.ReadLine());
        /* switch (numtov)
         {
             case 1:
                 korz.NameTov = vibor;


         }*/
        Adress adress = new Adress();//инициализировал элемент класса Адрес 
        Console.ReadLine();
        Order<Delivery> order1 = new Order<Delivery>();
        Console.WriteLine("Выберите способ доставки:\n 1 - Если нужна доставка на дом \n 2 - Если требуется доставка до Постамата \n 3 - Если вы хотите забрать товар из магазина");
        int change = Convert.ToInt32(Console.ReadLine());
        switch (change)
        {
            case 1:
                order1.Delivery = new HomeDelivery();
                HomeDelivery homeDelivery = new HomeDelivery();
                homeDelivery.SetHomeAdr();
                homeDelivery.Getadress();
                break;
            case 2:
                Console.WriteLine("Вы выбрали доставку в постамат");
                Console.WriteLine("Доступны следующие точки:");
                foreach (var adr in adress.PickAdr)
                    Console.WriteLine(adr);
                Order<Delivery> order2 = new Order<Delivery>();
                order2.Delivery = new PickPointDelivery(32442);
                Console.WriteLine(order1.Delivery);
                break;
            case 3:
                Console.WriteLine("Вы выбрали доставку в магазин");
                Order<Delivery> order3 = new Order<Delivery>();
                order3.Delivery = new ShopDelivery();

               // new Order<HomeDelivery>= new(,)


                break;
        }

        #region Code_switch
        /* object tov = Console.ReadLine();
         switch (tov)
         {
             case 1:
                 Console.WriteLine("ganteli");
                 break;
             case 2:
                 Console.WriteLine();
                 break;
             case 3:



         } */
        #endregion
        Console.WriteLine("Выведем введенный адрес");

        adress.InputAdressPick();
        adress.InputAdressHome();

        Order<Delivery> order = new Order<Delivery>();
        
        order.Delivery.Getadress();
        order.DisplayAddress();
        // Adress adresss = new Adress();

        //-----------------  от Олега  ----  Вариант Выбора Доставки  ----------------------------------------
        Console.WriteLine("Введите  choice :");
        int choice = Convert.ToInt32(Console.ReadLine());
         switch (choice)
         {
             case 1:
                 {
                     order.Delivery = new ShopDelivery();
                    
                     break;
                 }
             case 2:
                 {
                    int key = 0;
                     Console.WriteLine("Доступны следующие точки:");
                     foreach (var adr in adress.PickAdr)
                     Console.WriteLine(adr);

                     Console.WriteLine("Выберете по номеру (от 1 до {0})", adress.PickAdr.Length);
                    //  key = key.GetNumber(1, adress.PickAdr.Length);
                    //order.Delivery = new PickPointDelivery(adress.PickAdr[key - 1]);
                     break;
                 }
             case 3:
                 {
                     order.Delivery = new HomeDelivery(/*buyer.Address*/);//buyer - покупатель и запускаем метод адресс
                     break;
                 }
             default:
                 {
                     order.Delivery = new ShopDelivery();
                     break;
                 }
         }

        //--------------------------------------------------------------------------------------------------


        /*Product P1 = new Product(1, "Футболка с длинным рукавом", 1518.2, Product.Type.Футболка, "Вьетнам", Product.Sex.Men, "XXL");
        Product P2 = new Product(2, "Кроссовки беговые", 5450, Product.Type.Кроссовки, "Китай", Product.Sex.Women, "38");
        Product P3 = new Product(3, "Шорты теннисные", 2030, Product.Type.Шорты, "Тайланд", Product.Sex.Men, "L");
        Product P4 = new Product(4, "Футболка с коротким рукавом", 1318.8, Product.Type.Футболка, "Вьетнам", Product.Sex.Men, "XL");
        Product P5 = new Product(5, "Футболка с коротким рукавом", 1420.8, Product.Type.Футболка, "Вьетнам", Product.Sex.Women, "M");*/
        // Ввод адреса

        Random random = new Random();
        int a;
        a = random.Next(100);
    }

    abstract class Delivery
    {
        abstract public Adress Adress { get; set; } 
        abstract public string PriceDelivery { get; set; }

        abstract public void Getadress();
        
    }

    class HomeDelivery : Delivery
    {
        public override Adress Adress { get; set;}
        public override string PriceDelivery { get; set;}
       
        public void SetHomeAdr()
        {
            
            Console.WriteLine("Вы выбрали доставку на дом, введите свой адрес для доставки :");

            Console.WriteLine("Введите индекс вашего населеннго пункта :");
            Adress.indexcity = Console.ReadLine();
            Console.WriteLine("Введите ваш город :");
            Adress.city = Console.ReadLine();
            Console.WriteLine("Введите вашу улицу :");
            Adress.street = Console.ReadLine();
            Console.WriteLine("Введите номер дома :");
            Adress.house = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите номер квартиры:");
            Adress.appartment = Convert.ToInt32(Console.ReadLine());
           
        }
        public override void Getadress() // Метод вывода адреса 
        {
            Console.WriteLine($"DELIVERY выводим из Метод Getadress адресс из Delivery Город {Adress.city}, улица {Adress.street}, дом {Adress.house}");
        }
    }

    class PickPointDelivery : Delivery
    {
        public int boxnumber;
        public override Adress Adress { get; set; }
        public override string PriceDelivery { get; set; }
        public void SetPickAdr()
        {

            Console.WriteLine("Вы выбрали доставку в Постамат :");
            Console.WriteLine($"{Adress.PickAdr[0]} или {Adress.PickAdr[1]}");
            Console.WriteLine($" номер вашего заказа :{boxnumber}");
            
        }
        public PickPointDelivery(int boxnumber)
        {
            this.boxnumber = boxnumber;
            
        }
    public override void Getadress()
    {
        Console.WriteLine("DELIVERY выводим из Метод Getadress адресс из Delivery");
    }
}

    class ShopDelivery : Delivery
    {
        public override Adress Adress { get; set; }
        public override string PriceDelivery { get; set; }

        public string shopadress = "г.Уфа, ул.Черниковская 87 ";
        public override void Getadress()
        {
            Console.WriteLine("DELIVERY выводим из Метод Getadress адресс из Delivery");
        }
    }

    // Заказ 
    class Order<TDelivery> where TDelivery : Delivery
    {
        public TDelivery Delivery;//что это нам дает

        public int Number;//номер ордера

        public string Description;
        public string TovaryVkorzine;// список выбранных товаров

        public Product[] product;//что это нам дает
        public string prod;
        public void InProduct(Product[] product)
        {
            product = product;
            foreach(Product p in product)
            {
                Console.WriteLine(p.pd.ToString(), p.name, "-", p.cash, "рублей");
            }
        }
        public Order()
        {
            
        }

        public Order(TDelivery delivery, int number, string description, Product product)
        {
            Delivery = delivery;
            Number = number;
            Description = description;
           // this.product = product;
        }

        public void DisplayAddress()
        {
            Console.WriteLine("ORDER выводим из Метод Дисплей адресс из ордера");
            Console.WriteLine(Delivery.Adress);//откуда берется адресс 
            Console.WriteLine("выводим Product.name");
            //Console.WriteLine(product);
        }
        //private Product product;
        //public Order (Product product)
        //{
        //    this.product = product;
        //}

        // ... Другие поля
    }
     class Product //Заполнение из Main
    {
        public int pd;
        public string name;
        public int cash;
        public Product(int id,string Name, int cash)
        {
            pd = id;
            name = Name;
            this.cash = cash;
        }
    }
    class Gantel 
    {
        public string gantel;
    }
    class Girya 
    {
       
    }
    class Griff 
    {
        public string shtanga ;
    }
    class Blini 
    {
        public string blin;
    }


    public class Adress
    {
        private string IndexCity;
        private string City;
        private string Street;
        private int House;
        private int Appartment;
        public string indexcity { get { return IndexCity; } set { IndexCity = value; } }
        public string city { get { return City; } set { City = value; } }
        public string street { get { return Street; } set { Street = value; } }
        public int house { get { return House; } set { House = value; } }
        public int appartment { get { return Appartment; } set { Appartment = value; } }

        
        public Adress(string index, string city, string street, int house, int appart)
        {
            indexcity = index;
            this.city = city;
            this.street = street;
            this.house = house;
            appartment = appart;
        }
        public void InputAdressPick()
        {
            Console.WriteLine($"{PickAdr[0]} ,\n {PickAdr[1]} ");
            Console.WriteLine($"{IndexCity} , {City} , {Street}, {House}" );
        }
        public void InputAdressHome()
        {
            Console.WriteLine($"{IndexCity} , {City} , {Street}, {House}");
        }
        public Adress()
        {

        }
        public string ShopAdr;
        public string[] PickAdr;
        public Adress(string pick)
        {
            PickAdr[0] = "Первая точка какойто город1 улица1 и дом1";
            PickAdr[1] = "Вторая точка какойто город2 улица2 и дом2";
        }
        public void GetNumber()
        {

        }

    }

    public class User
    {
        public Adress adress;

        public string Name;
        public string Family;
        public string Telephone;
        
        public User( string name, string family, string telephone)
        {
            Name = name;
            Family = family;
            Telephone = telephone;
        }
       /* User user = new User();
        Console.WriteLine("Введите ваше имя : ");
        user.Name = Console.ReadLine();
        Console.WriteLine("Введите вашу фамилию : ");
        user.Family = Console.ReadLine();
        Console.WriteLine("Введите ваш номер телефона :");
        user.Telephone = Console.ReadLine();*/
    }
    class Korziva
    {
        public string NameTov;
    }

}


