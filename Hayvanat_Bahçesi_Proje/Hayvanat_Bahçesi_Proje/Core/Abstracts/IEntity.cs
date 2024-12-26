using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hayvanat_Bahçesi_Proje.Core.Abstracts
{
    public interface IEntity
    {
        int X { get; set; }
        int Y { get; set; }
        bool IsDead { get; set; }
        string Name { get; }
        void Move(int limitX, int limitY);
        void Hunt(List<IEntity> entities);
        string GetAnimalInfo();

    }
}
