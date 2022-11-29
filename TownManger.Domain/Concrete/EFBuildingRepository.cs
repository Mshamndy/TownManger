using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownManger.Domain.Abstract;
using TownManger.Domain.Entities;


namespace TownManger.Domain.Concrete
{
    public class EFBuildingRepository : IBuildingRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Building> Buildings
        {
            get
            {
                return context.Buildings;
            }
        }

        public Building DeleteBuilding(int buildingID)
        {
            Building dbEntry = context.Buildings.Find(buildingID);

            if (dbEntry != null)
            {
                IEnumerable<Floor> DeletedFloorBuildings = context.Floors.Where(f => f.BuildingID == buildingID);
                foreach (var item in DeletedFloorBuildings)
                {
                    context.Floors.Remove(item);

                }
                IEnumerable<Unit> DeletedUnitsBuildings = context.Units.Where(f => f.BuildingID == buildingID);
                foreach (var item in DeletedUnitsBuildings)
                {
                    context.Units.Remove(item);

                }


                context.Buildings.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveBuilding(Building building)
        {
            if (building.BuildingID == 0)
            {
                context.Buildings.Add(building);
                for (int i = 1; i <= building.FloorNumbers; i++)
                {
                    Floor floor = new Floor
                    {
                        FloorName = building.BuildingName + "-Floor-" + (i),
                        BuildingID = building.BuildingID,
                        UnitNumbers = building.UnitNumberFloor
                    };
                    context.Floors.Add(floor);

                }

            }
            else
            {
                Building dbEntry = context.Buildings.Find(building.BuildingID);
                if (dbEntry != null)
                {
                    dbEntry.BuildingName = building.BuildingName;
                    
                    
                    




                }
            }
            context.SaveChanges();
        }
    }
}
