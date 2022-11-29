using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownManger.Domain.Entities;

namespace TownManger.Domain.Abstract
{
    public interface IResdientRepository
    {
        IEnumerable<Resdient> Resdients { get; }
        void SaveResdient(Resdient resdient);
        Resdient DeleteResdient(int resdientID);
        void AddUnit(Resdient resdient);
    }
}
