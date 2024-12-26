using Hayvanat_Bahçesi_Proje.Core.Abstracts;
using Hayvanat_Bahçesi_Proje.Core.Entities;
using Hayvanat_Bahçesi_Proje.Core.SpawnManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hayvanat_Bahçesi_Proje.Core.AnimalManagement
{
    public class AnimalMoveSimulation
    {
        static int totalMovement = 0;
        static int maxMovement = 1000;

        // Simülasyonun sonucuna göre True veya False döndüren fonksiyon
        public static bool Simulation(List<IEntity> entities, int limitX, int limitY)
        {
            Random random = new Random();
            bool isSimulationActive = true; // Başlangıçta simülasyon mümkün kabul edilir

            // 1. Hareket İşlemi
            var aliveEntities = entities.Where(e => !e.IsDead).OrderBy(a => random.Next()).ToList();

            foreach (var entity in aliveEntities)
            {
                int previousX = entity.X;
                int previousY = entity.Y;
                entity.Move(limitX, limitY);

                totalMovement += Math.Abs(entity.X - previousX) + Math.Abs(entity.Y - previousY);

                // Maksimum hareket kontrolü
                if (totalMovement > maxMovement)
                {
                    isSimulationActive = false; // Hareket limitini aşarsa simülasyon mümkün değil
                    Console.WriteLine("Simülasyon sona erdi, maksimum hareket aşıldı.");
                    break; // Simülasyonu sonlandır
                }

                Console.WriteLine($"{entity.Name}={entity.GetAnimalInfo()}<--------->Toplam Hareket:{totalMovement}");
            }

            if (!isSimulationActive)
                return isSimulationActive; // Eğer hareket limiti aşıldıysa False döndür

            // 2. Avlanma İşlemi
            var hunters = entities.Where(e => e is Wolf || e is Lion || e is Hunter).ToList();

            foreach (var hunter in hunters)
            {
                hunter.Hunt(entities);
            }

            // 3. Üreme İşlemi
            AnimalSpawnManager.spawnNewAnimal(entities);

            return isSimulationActive; // Eğer simülasyon başarıyla tamamlandıysa True döndür
        }
    }
}
