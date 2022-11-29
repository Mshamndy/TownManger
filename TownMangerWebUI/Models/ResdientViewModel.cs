using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TownManger.Domain.Entities;

namespace TownMangerWebUI.Models
{
    public class ResdientViewModel
    {
        public IEnumerable< Resdient> Resdients { get; set; }

        public string UnitNumber { get; set; }
        public string BuildingName { get; set; }
        public string FloorName { get; set; }








    }
}