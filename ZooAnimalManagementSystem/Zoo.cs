using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooAnimalManagementSystem
{
     class Zoo
    {
        private List<Animal> animals = new List<Animal>();
        public event EventHandler<Animal> OnAnimalAdded;

        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
            OnAnimalAdded?.Invoke(this, animal);
        }
        public List<Animal> GetAnimals() => animals;
       
    }

}
