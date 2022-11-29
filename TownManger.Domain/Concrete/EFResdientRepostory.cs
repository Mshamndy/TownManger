using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using TownManger.Domain.Abstract;
using TownManger.Domain.Entities;


namespace TownManger.Domain.Concrete
{
    public class EFResdientRepostory : IResdientRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Resdient> Resdients => context.Resdients.Include(r => r.Unit);

        public Resdient DeleteResdient(int resdientID)
        {
            Resdient dbEntry = context.Resdients.Find(resdientID);
            if (dbEntry != null)
            {
                context.Resdients.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public void AddUnit(Resdient resdient)
        {

            Unit unit = context.Units.Find(resdient.UnitID);
            unit.ResdientID = resdient.ResdientID;
            context.SaveChanges();
        }
        public void SaveResdient(Resdient resdient)
        {
            if (resdient.ResdientID == 0)
            {
                context.Resdients.Add(resdient);
              
            }
            else
            {
                Resdient dbEntry = context.Resdients.Find(resdient.ResdientID);
                if (dbEntry != null)
                {
                    dbEntry.ResdientName = resdient.ResdientName;
                    dbEntry.NID = resdient.NID;
                    dbEntry.Mobile = resdient.Mobile;
                    dbEntry.FamilyRelationship = resdient.FamilyRelationship;
                    dbEntry.UnitID = resdient.UnitID;
                    dbEntry.GarageUnitNum = resdient.GarageUnitNum;
                    dbEntry.ImagePath = resdient.ImagePath;
                    dbEntry.CarNumber = resdient.CarNumber;
                    dbEntry.BuildingID = resdient.BuildingID;
                    dbEntry.FloorID = resdient.FloorID;
                    Unit unit = context.Units.Find(resdient.UnitID);
                    unit.ResdientID = resdient.ResdientID;
                    if (resdient.ImageData != null)
                    {
                        dbEntry.ImageData = resdient.ImageData;
                        dbEntry.ImageMimeType = resdient.ImageMimeType;

                    }
                  




                }
            }
            context.SaveChanges();
        }
    }
}
