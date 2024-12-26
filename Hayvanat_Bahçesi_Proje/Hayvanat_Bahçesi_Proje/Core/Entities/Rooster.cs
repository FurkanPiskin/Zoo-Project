﻿using Hayvanat_Bahçesi_Proje.Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hayvanat_Bahçesi_Proje.Core.Entities
{
    public class Rooster:Animal
    {
        private static int _population = 0;

        public  override int Population
        {
            get => _population;
            set => _population = value;
        }
        public override string Name => "Horoz";
        public override string Species { get; set; }
        public Rooster(int x, int y, bool gender) : base(x, y, gender)
        {
            _population++;
            MovementRange = 1;
            Species = "Poultry";
        }
        public override bool CanBeHuntedBy(Animal animal)
        {
            return animal is Wolf;
        }
        public static void ShowPopulation()
        {
            Console.WriteLine($"Rooster population: {_population}");
        }
    }
}
