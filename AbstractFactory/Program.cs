using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

//Provide an interface for creating families of related or dependent objects
//without specifying their concrete classes.
namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            //create and run asian world
            var asian = new AnimalWorld<Asian>();
            asian.FoodChain();
            //create and run america world
            var america = new AnimalWorld<America>();
            america.FoodChain();

            Console.ReadKey();
        }
    }

    interface IContinentFactory
    {
        IHerbivore CreateHerbivore();
        ICanivore CreateCanivore();
    }

    interface IHerbivore
    {
        void Eat();
    }

    interface ICanivore
    {
        void Eat(IHerbivore herbivore);
    }

    class Asian : IContinentFactory
    {
        public IHerbivore CreateHerbivore()
        {
            return new Donkey();
        }

        public ICanivore CreateCanivore()
        {
            return new Tiger();
        }
    }

    class America : IContinentFactory
    {
        public IHerbivore CreateHerbivore()
        {
            return new Bisson();
        }

        public ICanivore CreateCanivore()
        {
            return new Lion();
        }
    }


    class Tiger : ICanivore
    {
        public void Eat(IHerbivore herbivore)
        {
            Console.WriteLine(this.GetType().Name + " eats " + herbivore.GetType().Name);
        }
    }

    class Donkey : IHerbivore
    {
        public void Eat()
        {
            Console.WriteLine(this.GetType().Name + "eats grass");
        }
    }

    class Lion : ICanivore
    {
        public void Eat(IHerbivore herbivore)
        {
            Console.WriteLine(this.GetType().Name + " eats " + herbivore.GetType().Name);
        }
    }

    class Bisson : IHerbivore
    {
        public void Eat()
        {
            Console.WriteLine(this.GetType().Name + " eats leaves");
        }
    }

    interface IAnimalWorld
    {
        void FoodChain();
    }

    class AnimalWorld<T> : IAnimalWorld where T : IContinentFactory, new()
    {
        private IHerbivore herbivore;
        private ICanivore canivore;
        private T factory;

        public AnimalWorld()
        {
            factory = new T();
            herbivore = factory.CreateHerbivore();
            canivore = factory.CreateCanivore();
        } 

        public void FoodChain()
        {
            herbivore.Eat();
            canivore.Eat(herbivore);
        }
    }


}
