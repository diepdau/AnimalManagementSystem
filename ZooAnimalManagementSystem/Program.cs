using System;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Channels;
using System.Xml.Linq;
using ZooAnimalManagementSystem;

namespace MyApplication
{

    class Program
    {
        static void Main(string[] args)
        {
            var myLion = new List<Lion>() {
            new Lion(name:"Lion",age:10,species:"Animal"),
            new Lion(name:"Lion1",age:13,species:"123"),
            new Lion(name:"Lion2",age:19,species:"123"),
            };


            //Lion myLion = new Lion("Lion",12,"Animal");
            //myLion.MakeSound();
            //myLion.showInfo();

            //Elephant myElephant = new Elephant("Elephant",13,"Animal 123");
            //myElephant.MakeSound();
            //myElephant.showInfo();

            //Monkey myMonkey = new Monkey("Monkey", 14, "Animal 111");
            //myMonkey.MakeSound();
            //myMonkey.showInfo();

            //age greater than
            Console.WriteLine("\nAge < 12");
            var kq = myLion.Where(l => l.Age < 12).ToList();
            foreach (var i in kq)
            {
                GetAnimalType(i);
            }

            ////species type
            Console.WriteLine("\nSpecies is animal");
            var typeSpecies = myLion.Where(l => l.Species.Trim() == "Animal").ToList();

            foreach (var i in typeSpecies)
            {
                GetAnimalType(i);
            }




            //Add animal
            Console.WriteLine("Enter animal name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter animal age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter animal species: ");
            string species = Console.ReadLine();
            Lion myLion1 = new Lion(name, age, species);
            Console.WriteLine("ADD Animal :");
            GetAnimalType(myLion1);

            myLion1.LionChanged += Animal_Changed;


        }

        // Event handler 
        private static void Animal_Changed(object sender, ChangedEventAnimal e)
        {
            Console.WriteLine($"The name of {e.Name} changed to {e.Name:C}");
            Console.WriteLine($"The age of {e.Age} changed to {e.Age:C}");
            Console.WriteLine($"The species of {e.Species} changed to {e.Species:C}");

        }

        //Extension Methods
        public static void GetAnimalType(Animal animal)
        {
            Console.WriteLine($"ShowInfo: Name: {animal.Name} \nAge: {animal.Age} \nSpecies: {animal.Species}\n");

        }

    }
}