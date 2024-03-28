using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    public class Program
    {
        public class Solger
        {
            public Solger(string name, string role)
            {
                Name = name;
                Role = role;
            }

            public string Name { get; set; }
            public string Role { get; set; }
        }

        public interface IAccessToWeapon
        {
            void PerformAccessOperations();
        }

        public class AccessToWeapon : IAccessToWeapon
        {
            public void PerformAccessOperations()
            {
                Console.WriteLine("Performing taking a weapon");
            }
        }

        public class AccessToWeaponProxy : IAccessToWeapon
        {
            private IAccessToWeapon accessToWeapon;
            private readonly Solger solger;

            public AccessToWeaponProxy(Solger solger)
            {
                this.solger = solger;
            }

            public void PerformAccessOperations()
            {
                if(solger.Role.ToUpper() == "ACTIVE" || solger.Role.ToUpper() == "MILITARY")
                {
                    accessToWeapon = new AccessToWeapon();
                    Console.WriteLine("Access for taking a weapon is on");
                    accessToWeapon.PerformAccessOperations();
                }
                else{
                    Console.WriteLine("Access for taking a weapon is denied");
                }

            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Solger wants to take a weapon");
            Solger solger1 = new Solger("Liam", "Active");
            AccessToWeaponProxy solger1Proxy = new AccessToWeaponProxy(solger1);
            solger1Proxy.PerformAccessOperations();
        }
    }
}
