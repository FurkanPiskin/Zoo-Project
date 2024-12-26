using Hayvanat_Bahçesi_Proje.Core.Abstracts;
using Hayvanat_Bahçesi_Proje.Core.Entities;
using Hayvanat_Bahçesi_Proje.Core.FactoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hayvanat_Bahçesi_Proje.Core.SpawnManager
{
    public static class AnimalSpawnManager
    {
        public static void spawnNewAnimal(List<IEntity> entities)
        {
            var random = new Random();
            List<Animal> newAnimals = new List<Animal>();  // Yeni hayvanları geçici olarak burada toplayacağız

            var groupedAnimals = entities.OfType<Animal>()
                                          .Where(a => !a.IsDead) // Ölü olmayan hayvanları alıyoruz
                                          .GroupBy(a => a.Species); // Türlerine göre grupla

            foreach (var group in groupedAnimals)
            {
                var animals = group.ToList();
                

                // Hayvanları eşleştir
                for (int i = 0; i < animals.Count; i++)
                {
                    // Eğer hayvanın spawn hakkı yoksa, geç
                    if (!animals[i].SpawnAllowed)
                        continue;

                    for (int j = i + 1; j < animals.Count; j++)
                    {
                        // Eğer hayvanın spawn hakkı yoksa, geç
                        if (!animals[j].SpawnAllowed)
                            continue;

                        // Cinsiyet farklı mı?
                        if (animals[i].Gender != animals[j].Gender)
                        {
                            int deltaX = Math.Abs(animals[i].X - animals[j].X);
                            int deltaY = Math.Abs(animals[i].Y - animals[j].Y);
                            int totalDelta = deltaX + deltaY;

                            // Koordinatlar birbirine çok yakınsa (örneğin 3 birimden yakın)
                            if (totalDelta <= 3)
                            {
                                bool gender = random.Next(0, 2) == 0; // Yeni hayvanın cinsiyetini rastgele belirle true ise erkek,false ise dişi
                                int x = (animals[i].X + animals[j].X) / 2; // Yeni hayvanın x:koordinatlarını hesapla
                                int y = (animals[i].Y + animals[j].Y) / 2; //Yeni hayvanın y: koordinatlarını hesapla

                                // Yeni hayvanı oluştur
                                var newAnimal = AnimalFactory.CreateAnimal(animals[i].Name, x, y, gender);
                                if(newAnimal.Species== "Poultry")
                                {
                                    if (newAnimal.Gender == true) { //Erkek
                                         newAnimal = AnimalFactory.CreateAnimal("Horoz", x, y, gender);
                                    }
                                    else // Dişi
                                    {
                                        newAnimal = AnimalFactory.CreateAnimal("Tavuk", x, y, gender);
                                    }
                                }

                                newAnimals.Add(newAnimal);  // Yeni hayvanı geçici listeye ekle
                                Console.WriteLine($"{animals[i].Name} ({(animals[i].Gender ? "Erkek" : "Dişi")}) ve {animals[j].Name} ({(animals[j].Gender ? "Erkek" : "Dişi")}) üredi, yeni {newAnimal.Species} ({(newAnimal.Gender ? "Erkek" : "Dişi")}) oluşturuldu.");

                                // Yeni doğan hayvana SpawnHakkı false yapılır
                                newAnimal.SpawnAllowed = false;

                                // Mevcut hayvanların SpawnHakkı da false yapılır
                                animals[i].SpawnAllowed = false;
                                animals[j].SpawnAllowed = false;

                                break; // Üreme gerçekleşti, bir sonraki eşleşmeye geç
                            }
                        }
                    }
                }
            }

            // Yeni hayvanları ana listeye ekle
            entities.AddRange(newAnimals);
        }
    }
    }
