using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TownManger.Domain.Entities
{
    public class Building
    {

        
        public int BuildingID { get; set; }
        public string BuildingName { get; set; }

        public int FloorNumbers { get; set; }
        public int UnitNumberFloor { get; set; } 
        public virtual ICollection<Floor> Floor { get; set; }
        public virtual ICollection<Resdient> Resdient { get; set; }


        public virtual ICollection<Unit> Units { get; set; }


    }
}
