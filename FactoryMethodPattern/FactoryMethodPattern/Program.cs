using System;

namespace FactoryMethodPattern
{
    public class Program
    {
  
        static void Main(string[] args)
        {
            Creator[] creators = new Creator[2];
            creators[0] = new CreatorTwo();
            creators[1] = new CreatorOne();

            foreach(Creator creator in creators)
            {
                Animal animal = creator.CreateAnimal();
                Console.WriteLine("Created {0}", animal.GetType().Name);
            }

            Console.ReadKey();
        }
    }

    abstract class Animal
    {

    }

    class Cat: Animal
    {

    }

    class Dog : Animal
    {

    }

    abstract class Creator
    {
        public abstract Animal CreateAnimal();
    }

    class CreatorOne:Creator
    {
        public override Animal CreateAnimal()
        {
            return new Cat();
        }
    }
    class CreatorTwo : Creator
    {
        public override Animal CreateAnimal()
        {
            return new Dog();
        }
    }
}
