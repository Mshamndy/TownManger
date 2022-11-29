using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace TownManger.Domain.Entities
{
   public class Family
    {
      
        public int FamilyID { get; set; }
        public string FamilyName { get; set; }
        public virtual ICollection<FamilyMem> FamilyMems { get; set; }
        public virtual ICollection<Unit> Units { get; set; }




    }
}
