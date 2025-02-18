using MyApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ZooAnimalManagementSystem
{
    class Monkey : Animal
    {
        public Monkey(string name, int age, string species) : base(name, age, species)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("The mokey says: mokey mokey");
        }

    }
}
