using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TownManger.Domain.Entities
{
    public class Resdient
    {
        [HiddenInput(DisplayValue = false)]
        public int ResdientID { get; set; }
        public int NID { get; set; }
        public string ResdientName { get; set; }
        public string Mobile { get; set; }
        public string FamilyRelationship { get; set; }
        public int? UnitID { get; set; }
        public int? BuildingID { get; set; }
        public int? FloorID { get; set; }


        public int GarageUnitNum { get; set; }
        public int CarNumber { get; set; }
        public string ImagePath { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        public virtual Unit Unit { get; set; }
        public virtual Building Building { get; set; }

        public virtual Floor Floor { get; set; }



        public virtual ICollection<Visitor> Visitors { get; set; }
        public virtual ICollection<FamilyMem> FamilyMems { get; set; }
        public virtual ICollection<Unit> Units { get; set; }



    }
}
