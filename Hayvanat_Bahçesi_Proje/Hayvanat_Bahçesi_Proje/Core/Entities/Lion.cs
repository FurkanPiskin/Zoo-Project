using Hayvanat_Bahçesi_Proje.Core.Abstracts;
using System;
using System.Collections.Generic;

namespace Hayvanat_Bahçesi_Proje.Core.Entities
{
    public class Lion : Animal
    {
        // Aslan türünün popülasyonu
        private static int _population = 0;

        // Population özelliğini get ve set metodu ile yönetiyoruz
        public  override int Population
        {
            get => _population;
            set => _population = value;
        }

        // Aslanın ismi
        public override string Name => "Aslan";
        public override string Species {get;set;}

        // Constructor
        public Lion(int x, int y, bool gender) : base(x, y, gender)
        {
            _population++;  // Her yeni aslan oluşturulduğunda popülasyon bir artar
            MovementRange = 4;  // Aslanın hareket mesafesi 4
            Species = "Lion";
        }

        // Avlanma yeteneği (diğer hayvanlar tarafından avlanabilir mi?)
        public override bool CanBeHuntedBy(Animal animal)
        {
            return animal is Wolf || animal is Lion;  // Aslan sadece kurtlar ve diğer aslanlar tarafından avlanabilir
        }
        public static void ShowPopulation()
        {
            Console.WriteLine($"Lion population: {_population}");
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
                    if (animal is Cow || animal is Sheep)
                    {
                        // Mesafeyi hesapla
                        int distance = Math.Abs(animal.X - this.X) + Math.Abs(animal.Y - this.Y);

                        // Eğer mesafe 8 birimden küçük veya eşitse, avlanabilir
                        if (distance <= 8)
                        {
                            Console.WriteLine($"{animal.Name} aslan tarafından avlandı!");
                            animal.Die();  // Avlanan hayvan öldürülür
                        }
                    }
                }
            }
        }
    }
}

/* public void Hunters(List<IEntity> entities)
        {
            // Avcı, hayvanları kontrol eder ve mesafeye göre avlama işlemini başlatır
            foreach (var entity in entities)
            {
                if (entity is Animal animal && !animal.IsDead)
                {
                    // Mesafeyi hesapla
                    int distance = Math.Abs(animal.X - this.X) + Math.Abs(animal.Y - this.Y);

                    // Eğer mesafe 8 birimden küçük veya eşitse, avlanabilir
                    if (distance <= 8)
                    {
                        Console.WriteLine($"{animal.Name} avcı tarafından avlandı!");
                        animal.Die(animal);
                    }
                }
            }
        }*/
