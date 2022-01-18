using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
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
        List<Product> ListTov = new List<Product>();
        foreach(var ls in tov)
        {
            ListTov.Add(ls);// заносим список товаров в Лист
        }
       
        // Вывод товаров из массива в консоль (просто для проверки работы листа) РАБОТАЕТ 
        //foreach (var ls in ListTov)
        //{
        //    Console.WriteLine($" {ls.pd} -- {ls.name} = {ls.cash} ");
        //}
       
        
        //----------------------------- Начало Программы ---------------------------------------------- 
        Console.WriteLine("\tДобро пожаловать в магазин спорт-инвентаря :");
       
        Console.WriteLine("Введите своё Имя :");
        string nm = Console.ReadLine();
        Console.WriteLine("Введите свою Фамилию :");
        string fn = Console.ReadLine();
        Console.WriteLine("Введите свой номер телефона :");
        string tn = Console.ReadLine();
        
        // Объявляем экземпляры класса для занесения в них значений
        Order<Delivery> MyOrder = new Order<Delivery>();
        MyOrder.user = new User(nm, fn, tn);
        Console.WriteLine("------ Данные приняты ------");
        Console.WriteLine("\tИмеются данные товары :");
        foreach(var p in tov)
        {
            Console.WriteLine( $" {p.pd} - {p.name} = {p.cash} рублей");
        }
        Console.WriteLine("-------------------------------------------------------------------------");
        int numtov;
        int muchtov;
        string choice; 
        //Product vibor = tov[numtov];
        do
        {
            Console.WriteLine("Выберите товар, введите номер товара :");
            numtov = Convert.ToInt32(Console.ReadLine());
            MyOrder.TovaryVkorzineList.Add(ListTov[numtov]);
            Console.WriteLine(" Укажите количество :");
            muchtov = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < muchtov; i++)
            {
                MyOrder.TovaryVkorzineList.Add(ListTov[numtov]);
            }
            Console.WriteLine("Желаете ли вы добавить еще товары в корзину ? :\n Да/Нет");
            choice = Console.ReadLine();
        }
        while (choice == "да" | choice == "Да");
        Console.WriteLine("-------------------------------------------------------------------------");
        Console.WriteLine("Вы выбрали следующие товары :");
        foreach (var t in MyOrder.TovaryVkorzineList)
        {
            Console.WriteLine($"{t.name} , {t.cash} ");
        }
        int sum =0;
        foreach (var t in MyOrder.TovaryVkorzineList)
        {
            sum += t.cash;
        }
            Console.WriteLine($"общая сумма покупки составляет : {sum}");
        // вот тут должен быть способ как добавить кудато ( у меня в Ордере есть перменная TovaryVkorzine)
        // список выбранных товаров и их количество для дальнейшего подсчета

        Adress adress = new Adress();
        //MyOrder.Delivery.Adress.InputAdressPick();
        Console.WriteLine("Выберите способ доставки:\n 1 - Если нужна доставка на дом \n 2 - Если требуется доставка до Постамата \n 3 - Если вы хотите забрать товар из магазина");
        int change = Convert.ToInt32(Console.ReadLine());
        switch (change)
        {
            case 1:
                MyOrder.Delivery = new HomeDelivery(adress);// Не понятно зачем эта запись, знаю лишь одно что теперь
                var homedeliv = (HomeDelivery)MyOrder.Delivery;          // в классе Ордер (public TDelivery Delivery - будет понимать что это HomeDelivery()
                                                                         // но обратиься кполям HomeDelivery() всё рано не могу через эту переменную или вызвать метод
                                                                         //HomeDelivery homeDelivery = new HomeDelivery();// Создаю экземпляр класса т.к. не знаю как вызвать следующие два метода которые ниже
                homedeliv.SetHomeAdr();// Запускаем метод ввода адреса Заказчика
                homedeliv.Getadress(); // смотрим что ввёл Заказчик (просто чтоб проверить пока) 
                break;
            
            case 2:
                Console.WriteLine("Вы выбрали доставку в постамат");
                //MyOrder.Delivery = new PickPointDelivery(645982);// Цифры в скобках это boxnumber для присваивания номера отправления посылки, по идее должен в ордер вкладываться при необходимости
                MyOrder.Delivery = new PickPointDelivery();
                var pickpoit = (PickPointDelivery)MyOrder.Delivery;
               // PickPointDelivery pickPointDelivery = new PickPointDelivery();// пришлось объявить очередной экземпляр класса для вызова метода SetPickAdr(ii)
                Console.WriteLine("Доступны следующие точки:");
                foreach (var adr in adress.PickAdr) // Переменная-массив со списком точек выдачи из класса Адресс . но сначала должен быть вызван конструктор 
                    Console.WriteLine($"{adr}");
                //тут надо дописать какую точки мы выбрали и она должна попасть в Ордер для вывода итоговой информации 
                Console.WriteLine("Введите номер постамата ");
                int ii = Convert.ToInt32(Console.ReadLine());
                pickpoit.SetPickAdr(ii);// выбираем постамат
                                        //pickPointDelivery.SetPickAdr(ii);// выбираем постамат
                                        // Console.WriteLine(MyOrder.Delivery);
                break;
            
            case 3:
                Console.WriteLine("Вы выбрали доставку в магазин");
                MyOrder.Delivery = new ShopDelivery();// просто так написал чтобы было
                break;
        }
        // к этому моменту по идее в MyOrder должны быть все данные о товаре , способе доставке, адрессе и сумме покупок
        //но как это туда попадет непонятно, по идее мы switch case просто указали к чему будет относиться MyOrder к MyOrder.Delivery = new HomeDelivery();
        // или  MyOrder.Delivery = new ShopDelivery(); но что мы этим добились мне непонятно
        // или же в кейсах должна быть логика заполнения полностью ордера и потом мы просто выводим в консоль сводые данные
        // По идее после switch case  мы должны получить конкретный вариант MyOrder и с ним уже работь, дозапонять
        // хотя непонятно как мы получим MyOrder после прохождения кейсов.   

        //Дальше просто попытка вывести методы для понятия функционирования метода и их
        //взаимосвязи с введенными данными адреса при выборе доставки  MyOrder.Delivery = new HomeDelivery() 
        Console.WriteLine("Выведем введенный адрес");
        MyOrder.DisplayAddress();
        adress.InputAdressPick();
        adress.InputAdressHome();
        MyOrder.Delivery.Getadress();
        MyOrder.DisplayAddress();


    }

    abstract class Delivery // Базовый класс 
    {
        abstract public Adress Adress { get; set; } // посмотрел на тебя и попробовал сделать так же ( наследовать Адрес в вариантах доставкок
        abstract public int PriceDelivery { get; set; }
        abstract public void Getadress();// Метод вывода адреса
    }

    class HomeDelivery : Delivery
    {
       
        public override Adress Adress { get; set;}
        public override int PriceDelivery { get; set;} //цена по идее должна быть жестко прописана , но её надо назначить
        public void GetPrice(int num)// num количество товаров к примеру
        {
            PriceDelivery = num * 100;
        }
        public HomeDelivery(Adress adress)
        {
            Adress = adress;
        }
        public void SetHomeAdr()// Ввод адреса для доставки
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
        public int boxnumber;//значение попадает из конструктора
        public override Adress Adress { get; set; }
        public override int PriceDelivery { get; set; }
        public void GetPrice(int num)// num количество товаров к примеру
        {
            PriceDelivery = num * 100;
        }
        public void SetPickAdr(int num)// Выбор постамата но недоделанно 
        {
            Console.WriteLine("Вы выбрали доставку в Постамат :");
            Console.WriteLine($"{Adress.PickAdr[num]} ");
            Console.WriteLine($" номер вашего заказа :{boxnumber}");
        }
       /* public PickPointDelivery(int boxnumber)// Присвоение номеру посылки ( должен в случае выбора этого типа доставки попадать в ордер
        {
            this.boxnumber = boxnumber;
        }*/
        public override void Getadress()
        {
           // Console.WriteLine($"Выводим адресс из PickPointDelivery{Adress.PickAdr[num]}");//не получилось реализовать
        }
    }


    class ShopDelivery : Delivery
    {
        public override Adress Adress { get; set; }
        public override int PriceDelivery { get; set; }
        public override void Getadress()
        {
            Console.WriteLine($" Адресс магазина : {Adress.ShopAdr}");
            Console.WriteLine("DELIVERY выводим из Метод Getadress адресс из ShopDelivery");
            Console.WriteLine( );
        }
    }

    // Заказ 
    class Order<TDelivery> where TDelivery : Delivery
    {
        public User user;
        public TDelivery Delivery;//что это нам дает
        public int Number;//номер ордера надо как то назначить ( к примеру рандом )
        public string Description;
        public string[] TovaryVkorzine;// список выбранных товаров или List 
        
        public List<Product> TovaryVkorzineList = new List<Product> { };// как вариант
       
        public Product product;



        public string prod;
        public void InProduct(Product[] product)// метод для вывода массива товаров из полей класса Продукт 
        {
           var allproduct = product;
            foreach(Product p in allproduct)
            {
                Console.WriteLine(p.pd.ToString(), p.name, "-", p.cash, "рублей");
            }
        }
        public Order()// пустой конструктор
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
            Console.WriteLine("ORDER выводим  Метод Дисплей адресс из ордера");
            //foreach(var adr in Delivery.Adress)
            Console.WriteLine(Delivery.Adress);//откуда берется адресс 
            Console.WriteLine("выводим Product.name");
            //Console.WriteLine(product);
        }
        
        public User User { get; set; }
        
    }
     class Product //Заполнение из Main
    {
        public int pd;
        public string name;
        public int cash;
        public int much;
        public Product(int id,string Name, int cash)
        {
            pd = id;
            name = Name;
            this.cash = cash;
        }
    }
   

    public class Adress
    {
        public Adress GetAdress()
        {
            return new Adress();
        }

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

        /*public void SetHomeAdr()// Ввод адреса для доставки
        {
            Console.WriteLine("Вы выбрали доставку на дом, введите свой адрес для доставки :");
            Console.WriteLine("Введите индекс вашего населеннго пункта :");
            indexcity = Console.ReadLine();
            Console.WriteLine("Введите ваш город :");
            city = Console.ReadLine();
            Console.WriteLine("Введите вашу улицу :");
            street = Console.ReadLine();
            Console.WriteLine("Введите номер дома :");
            house = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите номер квартиры:");
            appartment = Convert.ToInt32(Console.ReadLine());
        }*/
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
        public string ShopAdr = "г.Уфа, ул.Черниковская 87 ";
        public string[] PickAdr = { "Первая точка какойто город1 улица1 и дом1" , "Вторая точка какойто город2 улица2 и дом2" };
        // должен содержать в себе пару адресов 
        // обращение по индексу в массиве PickAdr[i]

        public void ViewPick(int i)
        {
            Console.WriteLine(" Вы выбрали данный постамат : ");
            Console.WriteLine($" {PickAdr[i]} ");
        }

        public Adress(string pick)//работает ли это
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
        //public Adress adress;

        public string Name;
        public string Family;
        public string Telephone;
        
        public User( string name, string family, string telephone)
        {
            Name = name;
            Family = family;
            Telephone = telephone;
        }
       
    }
    class Korziva
    {
        public string NameTov;
        public string MuchTov;

        public Korziva(string nameTov, string muchTov)
        {
            NameTov = nameTov;
            MuchTov = muchTov;
        }
    }

}


