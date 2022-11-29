using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownManger.Domain.Entities
{
   public class FamilyMem
    {
        public int FamilyMemID { get; set; }

        public int? FamilyID { get; set; }
        public string RelationShip { get; set; }
        public string Mobile { get; set; }
        public int? ResdientID { get; set; }

        public virtual Resdient Resdient { get; set; }

        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Family Family { get; set; }
    }
}
