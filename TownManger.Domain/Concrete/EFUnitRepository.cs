using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TownManger.Domain.Abstract;
using TownManger.Domain.Entities;

namespace TownManger.Domain.Concrete
{
    public class EFUnitRepository : IUnitRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Unit> Units
        {
            get
            {
                return context.Units;
            }
        }

        public Unit DeleteUnit(int unitID)
        {

            Unit dbEntry = context.Units.Find(unitID);

            if (dbEntry != null)
            {
                //IEnumerable<Unit> DeletedFloorBuildings = context.Floors.Where(f => f.BuildingID == unitID);
                //foreach (var item in DeletedFloorBuildings)
                //{
                //    context.Floors.Remove(item);

                //}
                context.Units.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveUnit(Unit unit)
        {
            if (unit.UnitID == 0)
            {
                context.Units.Add(unit);
            }
            else
            {
                Unit dbEntry = context.Units.Find(unit.UnitID);
                if (dbEntry != null)
                {
                    dbEntry.UnitNumber = unit.UnitNumber;




                }
            }
            context.SaveChanges();

        }
    }
}
