using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownManger.Domain.Abstract;
using TownManger.Domain.Entities;

namespace TownManger.Domain.Concrete
{

    public class EFFloorRepository : IFloorRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Floor> Floors
        {
            get
            {
                return context.Floors;
            }
        }

        public Floor DeleteFloor(int floorID)
        {
            Floor dbEntry = context.Floors.Find(floorID);
            if (dbEntry != null)
            {
                context.Floors.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void SaveFloor(Floor floor)
        {
            if (floor.FloorID == 0)
            {
                context.Floors.Add(floor);


            }
            else
            {
                Floor dbEntry = context.Floors.Find(floor.FloorID);
                if (dbEntry != null)
                {
                    dbEntry.FloorName = floor.FloorName;
                    dbEntry.UnitNumbers = floor.UnitNumbers;


                }
            }
            context.SaveChanges();
        }
    }
}

