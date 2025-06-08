using System;
using System.Collections.Generic;

namespace ZooManager
{
    // Interface
    public interface IAnimal
    {
        string Name { get; }
        string Species { get; }
        int Age { get; }

        void MakeSound();
    }

    // Lion class
    public class Lion : IAnimal
    {
        public string Name { get; private set; }
        public string Species => "Lion";
        public int Age { get; private set; }

        public Lion(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void MakeSound()
        {
            Console.WriteLine($"{Name} the {Species} roars!");
        }
    }

    // Parrot class
    public class Parrot : IAnimal
    {
        public string Name { get; private set; }
        public string Species => "Parrot";
        public int Age { get; private set; }

        public Parrot(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void MakeSound()
        {
            Console.WriteLine($"{Name} the {Species} says: 'Polly wants a cracker!'");
        }
    }

    // Zoo class
    public class Zoo
    {
        private List<IAnimal> animals = new List<IAnimal>();

        public void AddAnimal(IAnimal animal)
        {
            animals.Add(animal);
        }

        public void ShowAllAnimals()
        {
            Console.WriteLine("Animals in the Zoo:");
            foreach (var animal in animals)
            {
                Console.WriteLine($"{animal.Name} - {animal.Species}, Age: {animal.Age}");
                animal.MakeSound();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Zoo myZoo = new Zoo();

            IAnimal lion1 = new Lion("Simba", 5);
            IAnimal parrot1 = new Parrot("Polly", 2);

            myZoo.AddAnimal(lion1);
            myZoo.AddAnimal(parrot1);

            myZoo.ShowAllAnimals();
        }
    }
}
