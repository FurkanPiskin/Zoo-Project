

using Hayvanat_Bahçesi_Proje.Core.Abstracts;
using Hayvanat_Bahçesi_Proje.Core.AnimalManagement;
using Hayvanat_Bahçesi_Proje.Core.Entities;
using Hayvanat_Bahçesi_Proje.Core.FactoryPattern;
using Hayvanat_Bahçesi_Proje.Core.SpawnManager;
using System;

namespace Hayvanat_Bahçesi_Proje
{

    class Program
    {    
      static void Main(string[] args)
        {
            AnimalSpawner animalSpawner = new AnimalSpawner();
            List<IEntity> entities = new List<IEntity>();
            Hunter hunter = new Hunter();
            int sayac = 0;
            bool control;

            int limitX = 500;
            int limitY = 500;

            entities.Add(hunter);
            animalSpawner.SheepSpawner(entities,30);
            animalSpawner.WolfSpawner(entities, 10);
            animalSpawner.CowSpawner(entities, 8);
            animalSpawner.ChickenSpawner(entities, 10);
            animalSpawner.RoosterSpawner(entities, 10);
            animalSpawner.LionSpawner(entities, 8);

            do
            {
                sayac++;
                Console.WriteLine($"MoveTurn:{sayac}");
                Sheep.ShowPopulation();
                Cow.ShowPopulation();
                Chicken.ShowPopulation();
                Rooster.ShowPopulation();
                Lion.ShowPopulation();
                Wolf.ShowPopulation();
                control = AnimalMoveSimulation.Simulation(entities,limitX,limitY);
                Console.WriteLine("****************************************");
                Console.WriteLine("\n");

            } while (control);

            Sheep.ShowPopulation();
            Cow.ShowPopulation();
            Chicken.ShowPopulation();
            Rooster.ShowPopulation();
            Lion.ShowPopulation();
            Wolf.ShowPopulation();
            Animal.TotalPopulation(entities);
            Console.ReadLine();
        }
            




            
        }
    }
