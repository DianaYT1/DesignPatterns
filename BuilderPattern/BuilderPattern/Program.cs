using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static BuilderPattern.Cars;

namespace BuilderPattern
{
    public class Cars
    {
        private string carMark;

        private Dictionary<string, string> cars = new Dictionary<string, string>();

        public Cars(string carMark)
        {
            this.carMark = carMark;
        }

        public string this[string key]
        {
            get => cars[key];
            set => cars.Add(key, value);
        }

        public void ShowMarks()
        {
            Console.WriteLine($"Car: {carMark}");
            Console.WriteLine($"Car Mark: {cars["mark"]}");
            Console.WriteLine($"Year of release: {cars["yearOfRelease"]}");
        }
    }

    public abstract class CarsBuilder
    {
        protected Cars cars;
        public Cars Cars => cars;

        public abstract void AddMark();
        public abstract void AddYearOfRelease();
    }

    public class MercedesCarsBuilder : CarsBuilder
    {
        public MercedesCarsBuilder()
        {
            cars = new Cars("Mercedes");
        }

        public override void AddMark()
        {
            cars["mark"] = "Mercedes";
        }

        public override void AddYearOfRelease()
        {
            cars["yearOfRelease"] = "SomeYear";
        }
    }

    public class FerrariCarsBuilder : CarsBuilder
    {
        public FerrariCarsBuilder()
        {
            cars = new Cars("Ferrari");
        }

        public override void AddMark()
        {
            cars["mark"] = "Ferrari";
        }

        public override void AddYearOfRelease()
        {
            cars["yearOfRelease"] = "SomeYear";
        }
    }

    public class Constructor
    {
        public void MakeCar(CarsBuilder carsBuilder)
        {
            carsBuilder.AddMark();
            carsBuilder.AddYearOfRelease();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Constructor constructor = new Constructor();

            CarsBuilder mercedesCarBuilder = new MercedesCarsBuilder();
            constructor.MakeCar(mercedesCarBuilder);
            mercedesCarBuilder.Cars.ShowMarks();

            Console.ReadKey();
        }
    }
}


