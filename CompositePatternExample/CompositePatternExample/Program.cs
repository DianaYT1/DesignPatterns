using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CompositePatternExample
{
    public abstract class Candidate
    {
        public Candidate(string name,int age, double salary, string division)
        {
            Name = name;
            Age = age;
            Salary = salary;
            Division = division;

        }
        protected string Name { get; set; }
        protected int Age { get; set; }

        protected double Salary { get; set; }

        protected string Division { get; set; }

        public abstract void Add(Candidate candidate);
        public abstract void Remove(Candidate candidate);

        public abstract void GetDivision(int divisionLevel);

    }

    public class LegionCommandant : Candidate
    {
        private List<Candidate> candidates = new List<Candidate>();

        public LegionCommandant(string name, int age, double salary, string division)
            : base(name, age, salary, division)
        {

        }

        public override void Add(Candidate candidate)
        {
            candidates.Add(candidate);
        }

        public override void Remove(Candidate candidate)
        {
            candidates.Remove(candidate);
        }

        public override void GetDivision( int divisionLevel)
        {
            Console.WriteLine($"{new string('-', divisionLevel)}+ {Name} {Age} [{Division}] [${Salary}]");
            foreach (Candidate candidate in candidates)
            {
                candidate.GetDivision(divisionLevel + ' ');
            }
        }
    }
    public class Soldat : Candidate
    {
        public Soldat(string name, int age, double salary, string division)
            : base(name, age, salary, division)
        {

        }


        public override void Add(Candidate candidate)
        {
            Console.WriteLine("Cannot add to a soldat");
        }

        public override void Remove(Candidate candidate)
        {
            Console.WriteLine("Cannot remove a soldat");
        }

        public override void GetDivision(int divisionLevel)
        {
            Console.WriteLine($"{new string('-', divisionLevel)}+ {Name} {Age} [{Division}] [${Salary}]");
        }
    }
    
    public class Program
    {
        static void Main(string[] args)
        {
            LegionCommandant legionCommander = new LegionCommandant("Adam", 24, 5000, "Soldat");
            
        }
    }
}
