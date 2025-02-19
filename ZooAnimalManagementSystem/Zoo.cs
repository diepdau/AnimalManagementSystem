using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Xml;
namespace ZooAnimalManagementSystem
{
     class Zoo
    {
        private List<Animal> animals = new List<Animal>();
        public event EventHandler<Animal> OnAnimalAdded;

        public  void AddAnimal(Animal animal)
        {
            animals.Add(animal);
            OnAnimalAdded?.Invoke(this, animal);
        }
        public List<Animal> GetAnimals() => animals;

        public async void SaveAnimalData(string nameFile)
        {
            Console.WriteLine("Loading data from a file.");
            string json = JsonSerializer.Serialize(animals, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(nameFile, json);
        }
        
    }

}

