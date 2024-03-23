using System;
using System.Collections.Generic;

namespace DecoratorPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("    GROSERY STORE");
            Console.WriteLine("-----------------------");

            Apple apple = new Apple("Clasic", 1, 10);
            apple.Display();

            Milk milk = new Milk("Cow milk", 2, 20);
            milk.Display();

            Console.WriteLine("\nSelling Milk:");
            SellItem sellMilk = new SellItem(milk);
            sellMilk.SellProduct("Customer #1");
            sellMilk.SellProduct("Customer #2");
            sellMilk.Display();

            Console.WriteLine("\nSelling Apple:");
            SellItem sellApple = new SellItem(apple);
            sellApple.SellProduct("Customer #1");
            sellApple.SellProduct("Customer #2");
            sellApple.Display();

            Console.ReadKey();

        }
    }

    //'GroseryStore' is a 'Component'
    public abstract class GroseryStore
    {
        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public abstract void Display();
    }

    //'ConcreteComponent' class
    public class Apple : GroseryStore
    {
        private string sort;
        private int price;

        public Apple(string sort, int price, int quantity)
        {
            this.sort = sort;
            this.price = price;
            this.Quantity = quantity;
        }

        public override void Display()
        {
            Console.WriteLine("\nApple ----------");
            Console.WriteLine("Sort: {0}", sort);
            Console.WriteLine("Price: {0}", price + "$");
            Console.WriteLine(" # Apples Quantity: {0}", Quantity);
        }
    }

    public class Milk : GroseryStore
    {
        private string mark;
        private int price;

        public Milk(string mark, int price, int quantity)
        {
            this.mark = mark;
            this.price = price;
            this.Quantity = quantity;
        }

        public override void Display()
        {
            Console.WriteLine("\nMilk ----------");
            Console.WriteLine("Mark: {0}", mark);
            Console.WriteLine("Price: {0}", price + "$");
            Console.WriteLine(" # Milk Quantity: {0}", Quantity);
        }
    }

    //'Decorator' abstarct class
    public abstract class Decorator : GroseryStore
    {
        protected GroseryStore groseryStore;

        public Decorator(GroseryStore groseryStore)
        {
            this.groseryStore = groseryStore;
        }

        public override void Display()
        {
            groseryStore.Display();
        }
    }

    public class SellItem : Decorator
    {
        protected readonly List<string> sellItems = new List<string>();

        public SellItem(GroseryStore groseryStore) 
            : base(groseryStore)
        {

        }

        public void SellProduct(string name)
        {
            sellItems.Add(name);
            groseryStore.Quantity--;
        }

        public override void Display()
        {
            base.Display();
        }
    }
}
