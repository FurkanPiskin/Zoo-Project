using Hayvanat_Bahçesi_Proje.Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hayvanat_Bahçesi_Proje.Core.Entities
{
    public class Cow:Animal
    {
        private static int _population = 0;

        public  override  int Population
        {
            get => _population;
            set => _population = value;
        }
        public override string Name => "İnek";
        public override string Species { get; set; }
        public Cow(int x, int y, bool gender) : base(x, y, gender)
        {
            _population++;
            MovementRange = 2;
            Species = "Cow";
        }
        public override bool CanBeHuntedBy(Animal animal)
        {
            return  animal is Lion;
        }
        public static void ShowPopulation()
        {
            Console.WriteLine($"Cow population: {_population}");
        }
    }
}
