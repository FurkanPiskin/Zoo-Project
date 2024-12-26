using Hayvanat_Bahçesi_Proje.Core.Abstracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hayvanat_Bahçesi_Proje.Core.Entities
{
    public class Hunter :IEntity
    {
        private static Random random = new Random();
        public int X { get; set; }
        public int Y { get; set; } 
        public int MovementRange { get; protected set; }
        public bool IsDead { get; set; }=false;
            
        public string Name =>"Avcı";
        public Hunter()
        {
            X = random.Next(0, 500);
            Y = random.Next(0, 500);
            MovementRange = 1;
        }

        public void Move(int limitX, int limitY)
        {
            
            int deltaX = random.Next(-MovementRange, MovementRange + 1);
            int deltaY = random.Next(-MovementRange, MovementRange + 1);

            X = Math.Clamp(X + deltaX, 0, limitX);
            Y = Math.Clamp(Y + deltaY, 0, limitY);

        }

        public void Hunt(List<IEntity> entities)
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
                        animal.Die();
                    }
                }
            }
        }

        public string GetAnimalInfo()
        {
            return $"{Name} - Konum: ({X}, {Y})";
        }
    }
}
