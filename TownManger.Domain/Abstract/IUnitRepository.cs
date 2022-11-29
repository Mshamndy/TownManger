using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownManger.Domain.Entities;

namespace TownManger.Domain.Abstract
{
    public interface IUnitRepository
    {
         
        IEnumerable<Unit> Units { get; }
        void SaveUnit(Unit unit);
        Unit DeleteUnit(int unitID);
    }
}

