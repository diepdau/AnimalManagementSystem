using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooAnimalManagementSystem
{
    class ChangedEventAnimal : EventArgs
    {
        public string Name { get;  }
        public int Age { get; }
        public string Species { get;  }

        public ChangedEventAnimal(string name, int age, string species)
        {
            Name = name;
            Age = age;
            Species = species;

        }

    }
}