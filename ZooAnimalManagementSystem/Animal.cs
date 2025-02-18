using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooAnimalManagementSystem
{
    abstract class Animal 
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Species { get; set; }

        public Animal(string name, int age, string species)
        {
            Name = name;
            Age = age;
            Species = species;

        }
        public abstract void MakeSound();
        public void showInfo()
        {
            Console.WriteLine($"ShowInfo: Name: {Name} \nAge: {Age} \nSpecies: {Species}\n");

        }


    }
}
