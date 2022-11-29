using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownManger.Domain.Entities;

namespace TownManger.Domain.Abstract
{
    public interface IBuildingRepository
    {
        IEnumerable<Building> Buildings { get; }
        void SaveBuilding(Building building);
        Building DeleteBuilding(int buildingID);
    }
}
