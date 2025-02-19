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

        public List<Animal> FilterByAgeGreaterThan(int age)
        {
            return animals.Where(a => a.Age > age).ToList();
        }

        public List<Animal> FilterBySpecies(string species)
        {
            return animals.Where(a => a.Species == species).ToList();
        }

        public async Task SaveAnimalData(string nameFile)
        {
            Console.WriteLine("\nSaving data to file");
            string json = JsonSerializer.Serialize(animals, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(nameFile, json);
        }

        public async Task LoadAnimalData(string nameFile)
        {
            if (File.Exists(nameFile))
            {
                Console.WriteLine("\nLoading data from a file");
                string json = await File.ReadAllTextAsync(nameFile);
                animals = JsonSerializer.Deserialize<List<Animal>>(json) ?? new List<Animal>();
            }
            else
            {
                Console.WriteLine("File not found");
            }
        }

    }

}

