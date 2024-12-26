using Hayvanat_Bahçesi_Proje.Core.Abstracts;
using System;
using System.Collections.Generic;

namespace Hayvanat_Bahçesi_Proje.Core.Entities
{
    public class Wolf : Animal
    {
        // Kurt türünün popülasyonu
        private static int _population = 0;

        // Population özelliği
        public  override int Population
        {
            get => _population;
            set => _population = value;
        }

        // Kurtun ismi
        public override string Name => "Kurt";
        public override string Species { get ;set ; }

        // Constructor
        public Wolf(int x, int y, bool gender) : base(x, y, gender)
        {
            _population++;  // Her yeni kurt oluşturulduğunda popülasyon bir artar
            MovementRange = 3;  // Kurtun hareket mesafesi 3
            Species = "Wolf";
        }

        // Avlanma yeteneği (diğer hayvanlar tarafından avlanabilir mi?)
        public override bool CanBeHuntedBy(Animal animal)
        {
            return animal is Wolf || animal is Lion;  // Kurt sadece diğer kurtlar ve aslanlar tarafından avlanabilir
        }
        public static void ShowPopulation()
        {
            Console.WriteLine($"Wolf population: {_population}");
        }

        // Avcı olarak avlama fonksiyonu
        public override void Hunt(List<IEntity> entities)
        {
            // Tüm varlıklar üzerinde döngü başlatıyoruz
            foreach (var entity in entities)
            {
                // Eğer varlık bir hayvan ise ve ölü değilse
                if (entity is Animal animal && !animal.IsDead)
                {
                    // Eğer hayvan koyun ya da inek ise
                    if (animal is Chicken || animal is Sheep || animal is Rooster)
                    {
                        // Mesafeyi hesapla
                        int distance = Math.Abs(animal.X - this.X) + Math.Abs(animal.Y - this.Y);

                        // Eğer mesafe 8 birimden küçük veya eşitse, avlanabilir
                        if (distance <= 4)
                        {
                            Console.WriteLine($"{animal.Name} kurt tarafından avlandı!");
                            animal.Die(); 
                            // Avlanan hayvan öldürülür
                        }
                    }
                }
            }
        }
    }
}
