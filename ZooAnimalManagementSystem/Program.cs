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
            var myLion = new List<Lion>() {
            new Lion(name:"Lion",age:10,species:"Animal"),
            new Lion(name:"Lion1",age:13,species:"123"),
            new Lion(name:"Lion2",age:19,species:"123"),
            };


            
            //age greater than
            Console.WriteLine("\nAge < 12");
            var kq = myLion.Where(l => l.Age < 12).ToList();
            foreach (var i in kq)
            {
                i.showInfo();
            }

            //species type
            Console.WriteLine("\nSpecies is animal");
            var typeSpecies = myLion.Where(l => l.Species.Trim() == "Animal").ToList();

            foreach (var i in typeSpecies)
            {
                i.showInfo();
            }



            Zoo myZoo = new Zoo();
            myZoo.OnAnimalAdded += (sender, animal) =>
                Console.WriteLine($"New Animal : {animal.Name}, Age: {animal.Age}, Species: {animal.Species}");
            myZoo.AddAnimal(new Lion("Lion", 12, "Animal12"));
            myZoo.AddAnimal(new Elephant("Elephant", 13, "Animal"));
            myZoo.AddAnimal(new Monkey("Monkey", 14, "Animal"));

            //Save to file
            myZoo.SaveAnimalData(@"D:\animal.json");

            //Extension method
            Monkey monkey = new Monkey("monkey", 12, "Animal");
            Console.WriteLine("AnimalType: " + monkey.GetAnimalType());



        }

    }
  

}