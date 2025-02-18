using MyApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ZooAnimalManagementSystem
{
    class Lion:Animal, ICarnivore
    {
        public delegate void LionChangedHandler(object sender, ChangedEventAnimal e);
        public event LionChangedHandler LionChanged;
        public Lion(string name, int age, string species) : base(name, age, species)
        {
            OnLionChanged(new ChangedEventAnimal(name, age, species));

        }

        public void Hunt()
        {
            Console.WriteLine("Hunt goat, rabbit");
        }

        public override void MakeSound()
        {
            Console.WriteLine("The lion says: woa woa");
        }
        protected virtual void OnLionChanged(ChangedEventAnimal e)
        {
            LionChanged?.Invoke(this, e);
        }

    }
}
