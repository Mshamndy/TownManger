using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownManger.Domain.Entities;

namespace TownManger.Domain.Abstract
{
   public interface IFloorRepository
    {
        IEnumerable<Floor> Floors { get; }
        void SaveFloor(Floor floor);
        Floor DeleteFloor(int floorID);
    }
}
