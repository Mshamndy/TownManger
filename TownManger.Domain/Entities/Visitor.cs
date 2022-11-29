using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownManger.Domain.Entities
{
    public class Visitor
    {
        public int VisitorID { get; set; }
        public string VisitorName { get; set; }
        public Nullable<double> Photo { get; set; }
        public string NID { get; set; }
        public string Gender { get; set; }
        public string CarNumber { get; set; }
        public string Approve { get; set; }
        public string RelationShip { get; set; }
        public DateTime EnteranceTime { get; set; }
        public DateTime LeavingTime { get; set; }
        public int? ResdientID { get; set; }
        public string Mobile { get; set; }
        public virtual Resdient Resdient { get; set; }


    }
}
