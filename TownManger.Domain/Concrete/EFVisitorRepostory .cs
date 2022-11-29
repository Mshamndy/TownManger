//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TownManger.Domain.Abstract;
//using TownManger.Domain.Entities;


//namespace TownManger.Domain.Concrete
//{
//    public class EFVisitorRepostory : IVisitorRepository
//    {
//        private EFDbContext context = new EFDbContext();

//        public IEnumerable<Visitor> Visitors()
//        {
//            return context.Visitors;
//        }

//        public Visitor DeleteVisitor(int visitorID)
//        {
//            Visitor dbEntry = context.Visitors.Find(visitorID);
//            if (dbEntry != null)
//            {
//                context.Visitors.Remove(dbEntry);
//                context.SaveChanges();
//            }
//            return dbEntry;
//        }

//        public void SaveVisitor(Visitor visitor)
//        {
//            if (visitor.VistorID == 0)
//            {
//                context.Visitors.Add(visitor);
//            }
//            else
//            {
//                Visitor dbEntry = context.Visitors.Find(visitor.VistorID);
//                if (dbEntry != null)
//                {
//                    dbEntry.VisitortName = visitor.VisitortName;
//                    dbEntry.NID = visitor.NID;
//                    dbEntry.Mobile = visitor.Mobile;
//                    dbEntry.ResdientID = visitor.ResdientID;
//                    dbEntry.EnteranceTime = visitor.EnteranceTime;
//                    dbEntry.LeavingTime = visitor.LeavingTime;
//                    dbEntry.RelationShip = visitor.RelationShip;
//                    dbEntry.CarNumber = visitor.CarNumber;
//                    dbEntry.ImagePath = visitor.ImagePath;











//                }
//            }
//            context.SaveChanges();
//        }
//    }
//}
