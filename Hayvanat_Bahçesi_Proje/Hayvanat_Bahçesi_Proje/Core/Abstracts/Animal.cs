using Hayvanat_Bahçesi_Proje.Core.Abstracts;
using Hayvanat_Bahçesi_Proje.Core.FactoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hayvanat_Bahçesi_Proje.Core.Entities
{
    public abstract class Animal : IEntity
    {
        // Hayvanın mevcut koordinatları
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsDead { get; set; }
        public bool Gender { get; set; } // true: Erkek, false: Dişi
        public int MovementRange { get; protected set; }

        public bool SpawnAllowed { get; set; }

        // Her tür için ayrı bir sayaç
        public abstract int Population { get; set; }
        public abstract string Species { get; set; }

        // Constructor
        protected Animal(int x, int y, bool gender)
        {
            X = x;
            Y = y;
            Gender = gender;
            IsDead = false;
            SpawnAllowed = true;
        }

        // Her hayvanın kendine özgü ismi
        public abstract string Name { get; }

        // Hareket etme fonksiyonu, belirli limitlere göre hareket eder
        public void Move(int limitX, int limitY)
        {
            if (IsDead) return;  // Ölü hayvan hareket etmez

            Random rnd = new Random();
            int moveChance = rnd.Next(0, 2);
            int deltaX, deltaY;

            // Hareket mesafesi range içinde rastgele belirlenir
            if (moveChance == 1)
            {
                do
                {
                    deltaX = rnd.Next(-MovementRange, MovementRange + 1);
                    deltaY = rnd.Next(-MovementRange, MovementRange + 1);

                } while (Math.Abs(deltaX) + Math.Abs(deltaY) != MovementRange);
            }
            else {
                deltaX = 0;
                deltaY = 0;
            }

            // Yeni pozisyon hesaplanır ve sınıra göre kısıtlanır
            X = Math.Clamp(X + deltaX, 0, limitX);
            Y = Math.Clamp(Y + deltaY, 0, limitY);
        }

        // Avcının bu hayvanı avlayıp avlayamayacağını kontrol eder
        public abstract bool CanBeHuntedBy(Animal animal);

        // Hayvan bilgilerini yazdıran metod
        public string GetAnimalInfo()
        {
            return $"{Name} ({(Gender ? "Erkek" : "Dişi")}) - Konum: ({X}, {Y})";
        }

        // Hayvanın ölümünü işle
        public void Die()
        {
            IsDead = true;
            Population--;  // Hayvan öldü, türün popülasyonu azalır
            X = -10;  // Haritadan çıkarılması için koordinatlar güncellenir
            Y = -10;
            Console.WriteLine($"{Name} öldü ve haritadan kaldırıldı.");
        }
       

        // Avcı değil, normal hayvan
        public virtual void Hunt(List<IEntity> entities)
        {
            Console.WriteLine($"{Name} bir avcı değil.");
        }

        public static void TotalPopulation(List<IEntity> entities)
        {
            int total_population = 0;
            foreach (var entity in entities) {
                if (!entity.IsDead)
                {
                    total_population++;
                }
            }
            Console.WriteLine($"TotalAnimal:{total_population-1} with Hunter :{total_population}");
        }
        
       

    }
}
