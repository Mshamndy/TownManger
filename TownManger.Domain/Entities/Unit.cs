using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TownManger.Domain.Entities
{
    public class Unit
    {
        public int UnitID { get; set; }
        public int UnitNumber { get; set; }
        public int? BuildingID { get; set; }

        public int? FloorID { get; set; }

        public int? FamilyID { get; set; }
        public int? ResdientID { get; set; }

        public virtual Family Family { get; set; }
        public virtual Floor Floor { get; set; }
        public virtual ICollection<Resdient> Resdients { get; set; }
        public virtual Building Building { get; set; }
        public virtual Resdient Resdient { get; set; }



    }
}
