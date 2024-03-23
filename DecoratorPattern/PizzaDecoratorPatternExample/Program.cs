using System;

namespace PizzaDecoratorPatternExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Making Pizza --------");
            PlainPizza plainPizza1 = new PlainPizza();
            string plainPizza = plainPizza1.MakePizza();
            Console.WriteLine(plainPizza);

            Console.WriteLine("\nCustomer #1");
            PizzaDecorator peperonyPizzaDecorator = new PeperonyPizzaDecorator(plainPizza1);
            string peperonyPizza = peperonyPizzaDecorator.MakePizza();
            Console.WriteLine(peperonyPizza);

            Console.WriteLine("\nCustomer #2");
            PizzaDecorator cheesePizzaDecorator = new CheesePizzaDecorator(plainPizza1);
            string cheesePizza = cheesePizzaDecorator.MakePizza() + peperonyPizzaDecorator.MakePizza();

            Console.WriteLine(cheesePizza);

            Console.ReadKey();
        }

        public abstract class Pizza
        {
            public abstract string MakePizza();
        }

        public class PlainPizza: Pizza
        {
            public override string MakePizza()
            {
                return "Plain Pizza";
            }
        }

        public abstract class PizzaDecorator : Pizza
        {
            protected Pizza pizza;

            public PizzaDecorator(Pizza pizza)
            {
                this.pizza = pizza;
            }

            public override string MakePizza()
            {
                return pizza.MakePizza();
            }
        }

        public class PeperonyPizzaDecorator : PizzaDecorator
        {
            public PeperonyPizzaDecorator(Pizza pizza)
                : base(pizza) { }

            public override string MakePizza()
            {
                return base.MakePizza() + AddPeperony();
            }

            private string AddPeperony()
            {
                return ", Peperony added";
            }
        }

        public class CheesePizzaDecorator : PizzaDecorator
        {
            public CheesePizzaDecorator(Pizza pizza)
                : base(pizza) { }

            public override string MakePizza()
            {
                return base.MakePizza() + AddPeperony();
            }

            private string AddPeperony()
            {
                return ", Cheese added";
            }
        }
    }
}
//virtual or abstract methods connot be private