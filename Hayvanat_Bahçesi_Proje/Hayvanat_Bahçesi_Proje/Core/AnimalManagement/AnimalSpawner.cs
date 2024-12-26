using Hayvanat_Bahçesi_Proje.Core.Abstracts;
using Hayvanat_Bahçesi_Proje.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hayvanat_Bahçesi_Proje.Core.AnimalManagement
{
    public class AnimalSpawner
    {
        Random rnd = new Random();
        int maleCount = 0;
        int femaleCount = 0;
        public void SheepSpawner(List<IEntity> entities,int quantity){
            for (int i = 0; i < quantity; i++)
            {
                int x = rnd.Next(0, 100); // Rastgele X koordinatı (0 ile 500 arasında)
                int y = rnd.Next(0, 100); // Rastgele Y koordinatı (0 ile 500 arasında)
                bool gender;
                if (maleCount < quantity / 2)
                {
                    gender = true;//Erkek
                    maleCount++;
                }
                else
                {
                    gender = false;//Dişi
                    femaleCount++;
                }
                entities.Add(new Sheep(x, y, gender));


                if (i == quantity)
                {
                    maleCount = 0;
                    femaleCount = 0;
                }
            }
        }
        public void WolfSpawner(List<IEntity> entities,int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                int x = rnd.Next(0, 100); // Rastgele X koordinatı (0 ile 500 arasında)
                int y = rnd.Next(0, 100); // Rastgele Y koordinatı (0 ile 500 arasında)
                bool gender;
                if (maleCount < quantity / 2)
                {
                    gender = true;//Erkek
                    maleCount++;
                }
                else
                {
                    gender = false;//Dişi
                    femaleCount++;
                }
                entities.Add(new Wolf(x, y, gender));


                if (i == quantity)
                {
                    maleCount = 0;
                    femaleCount = 0;
                }
            }
        }
        public void RoosterSpawner(List<IEntity> entities,int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                int x = rnd.Next(0, 100); // Rastgele X koordinatı (0 ile 500 arasında)
                int y = rnd.Next(0, 100); // Rastgele Y koordinatı (0 ile 500 arasında)
                bool gender = true;
                entities.Add(new Rooster(x, y, gender));
            }
        }
        public void ChickenSpawner(List<IEntity> entities, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                int x = rnd.Next(0, 100); // Rastgele X koordinatı (0 ile 500 arasında)
                int y = rnd.Next(0, 100); // Rastgele Y koordinatı (0 ile 500 arasında)
                bool gender = false;
                entities.Add(new Chicken(x, y, gender));
            }
        }
        public void LionSpawner(List<IEntity> entities, int quantity)
        {
            for (int i = 0; i < 10; i++)
            {
                int x = rnd.Next(0, 100); // Rastgele X koordinatı (0 ile 500 arasında)
                int y = rnd.Next(0, 100); // Rastgele Y koordinatı (0 ile 500 arasında)
                bool gender;
                if (maleCount < quantity / 2)
                {
                    gender = true;//Erkek
                    maleCount++;
                }
                else
                {
                    gender = false;//Dişi
                    femaleCount++;
                }
                entities.Add(new Lion(x, y, gender));


                if (i == quantity)
                {
                    maleCount = 0;
                    femaleCount = 0;
                }
            }
        }
        public void CowSpawner(List<IEntity> entities, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                int x = rnd.Next(0, 100); // Rastgele X koordinatı (0 ile 500 arasında)
                int y = rnd.Next(0, 100); // Rastgele Y koordinatı (0 ile 500 arasında)
                bool gender;
                if (maleCount < quantity / 2)
                {
                    gender = true;//Erkek
                    maleCount++;
                }
                else
                {
                    gender = false;//Dişi
                    femaleCount++;
                }
                entities.Add(new Cow(x, y, gender));


                if (i == quantity)
                {
                    maleCount = 0;
                    femaleCount = 0;
                }
            }
        }
    }
}
