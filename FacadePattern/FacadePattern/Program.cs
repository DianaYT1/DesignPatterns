using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    public class Program
    {
        public class AmusementPark
        {
            public bool HasEnoughHigh(Person person,int height)
            {
                Console.WriteLine("Check person's high " + person.Height);
                return true;
            }
        }

        public class AgeGroup
        {
            public bool HasEnoughYears(Person person,int age)
            {
                Console.WriteLine("Check person's age " + person.Age);
                return true;
            }
        }

        public class Amount
        {
            public bool HasEnoughMoney(Person person,int amount)
            {
                Console.WriteLine("Check person's amount " + person.Amount);
                return true;
            }
        }
        //'Facade class'
        public class ParkEnterance
        {
            AmusementPark amusementPark = new AmusementPark();
            AgeGroup ageGroup = new AgeGroup();
            Amount money = new Amount();


            public bool IsEligible(Person person)
            {
                Console.WriteLine("{0} wants to enter the park. She need's to be atleast 16 years old, 160 height and to has to have 10$ ",
                    person.Name);

                bool eligible = true;

                if (!amusementPark.HasEnoughHigh(person, person.Height) || person.Height > 160)
                {
                    eligible = false;
                }
                else if (!ageGroup.HasEnoughYears(person, person.Age) || person.Age < 16)
                {
                    eligible = false;
                }
                else if (!money.HasEnoughMoney(person, person.Amount) || person.Amount < 10)
                {
                    eligible = false;
                }
                return eligible;
            }
        }
        public class Person
        {
            private string name;
            private int height;
            private int age;
            private int amount;
            public Person(string name, int age, int height, int amount)
            {
                this.name = name;
                this.age = age;
                this.height = height;
                this.amount = amount;
            }

            public string Name
            {
                get { return name; }
            }

            public int Height
            {
                get { return height; }
            }

            public int Age
            {
                get { return age; }
            }

            public int Amount
            {
                get { return amount; }
            }
        }
        static void Main(string[] args)
        {
            ParkEnterance parkEnterance = new ParkEnterance();
            Person person = new Person("Cortana ",19,160,5);
            bool eligible = parkEnterance.IsEligible(person);

            Console.WriteLine("\n" + person.Name + "has been " + (eligible ? "Approved" : "Rejected"));
            Console.ReadKey();
        }
    }
}
