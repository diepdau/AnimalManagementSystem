using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Xml;
using System.IO;
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

        public static async Task LoadAnimalData(string nameFile)
        {
            Console.WriteLine("\nLoading data from a file");

            string json = await File.ReadAllTextAsync(nameFile);
            using JsonDocument doc = JsonDocument.Parse(json);
            JsonElement root = doc.RootElement;

            if (root.ValueKind == JsonValueKind.Array)
            {
                List<Animal> animals = new List<Animal>();

                foreach (JsonElement element in root.EnumerateArray())
                {
                    string name = element.GetProperty("Name").GetString()!;
                    int age = element.GetProperty("Age").GetInt32();
                    string species = element.GetProperty("Species").GetString()!;

                    Animal animal = name switch
                    {
                        "Lion" => new Lion(name, age, species),
                        "Monkey" => new Monkey(name, age, species),
                        "Elephant" => new Elephant(name, age, species),
                        _ => null
                    };

                    animals.Add(animal);
                    Console.WriteLine($"Loaded: {animal.Name}, Age: {animal.Age}, Species: {animal.Species}");
                }
            }
    }



}

}

