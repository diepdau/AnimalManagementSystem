using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Channels;
using System.Xml.Linq;
using ZooAnimalManagementSystem;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Xml;

namespace MyApplication
{

    class Program
    {
        static async Task Main(string[] args)
        {
            Zoo myZoo = new Zoo();
            myZoo.AddAnimal(new Lion("Lion", 12, "Animal12"));
            myZoo.AddAnimal(new Elephant("Elephant", 13, "Animal"));
            myZoo.AddAnimal(new Monkey("Monkey", 14, "Animal"));

            //age greater than
            Console.WriteLine("\nAge > 12");
            var kq = myZoo.FilterByAgeGreaterThan(12);
            foreach (var i in kq)
            {
                i.showInfo();
            }

            //species type
            Console.WriteLine("\nSpecies is animal");
            var typeSpecies = myZoo.FilterBySpecies("Animal");
            foreach (var i in typeSpecies)
            {
                i.showInfo();
            }



            string fileName = @"D:\animals.json"; ;

            //myZoo.OnAnimalAdded += (sender, animal) =>
            //    Console.WriteLine($"New Animal : {animal.Name}, Age: {animal.Age}, Species: {animal.Species}");

            // Save to file
            await myZoo.SaveAnimalData(fileName);

            // Loading
            Console.WriteLine("\nRead animals:");
            await Zoo.LoadAnimalData(fileName);

         


            //Extension method
            Monkey monkey = new Monkey("monkey", 12, "Animal");
            Console.WriteLine("AnimalType: " + monkey.GetAnimalType());



        }

    }
  

}