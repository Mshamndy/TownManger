using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace TownManger.Domain.Entities
{
    public class Floor
    {
       

        public int FloorID { get; set; }
        public string FloorName { get; set; }

        public int? BuildingID { get; set; }
        public int UnitNumbers { get; set; }

        public virtual Building Buildings { get; set; }
        public virtual ICollection<Unit> Units { get; set; }

        public virtual ICollection<Resdient> Resdients { get; set; }





    }
}
