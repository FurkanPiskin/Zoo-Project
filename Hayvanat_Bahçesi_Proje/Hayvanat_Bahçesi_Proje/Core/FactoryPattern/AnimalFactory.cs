using Hayvanat_Bahçesi_Proje.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hayvanat_Bahçesi_Proje.Core.FactoryPattern
{
    public static class AnimalFactory
    {
        public static Animal CreateAnimal(string animalType, int x, int y, bool gender)
        {
            // Hayvan türüne göre nesne oluşturuluyor
            switch (animalType)
            {
                case "Koyun":
                    return new Sheep(x, y, gender);
                case "İnek":
                    return new Cow(x, y, gender);
                case "Aslan":
                    return new Lion(x, y, gender);
                case "Kurt":
                    return new Wolf(x, y, gender);
                case "Tavuk":
                    return new Chicken(x, y, gender);
                case "Horoz":
                    return new Rooster(x, y, gender);
                // Diğer hayvan türleri eklenebilir
                default:
                    throw new ArgumentException("Geçersiz hayvan türü");
            }
        }
    }
}
