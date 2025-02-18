using System;
using System.Drawing;
using System.Reflection;
using ZooAnimalManagementSystem;

namespace MyApplication
{
    abstract class Animal
    {
        protected string Name { get; set; }
        protected int Age { get; set; }
        protected string Species { get; set; }
        
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
    class Program
    {
        static void Main(string[] args)
        {
            Lion myLion = new Lion("Lion",12,"Animal");
            myLion.MakeSound();
            myLion.showInfo();

            Elephant myElephant = new Elephant("Elephant",13,"Animal 123");
            myElephant.MakeSound();
            myElephant.showInfo();

            Monkey myMonkey = new Monkey("Monkey", 14, "Animal 111");
            myMonkey.MakeSound();
            myMonkey.showInfo();
        }
    }
}