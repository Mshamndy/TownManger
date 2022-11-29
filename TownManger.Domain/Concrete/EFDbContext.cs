using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TownManger.Domain.Entities;
using System.Data.Entity.Infrastructure;


namespace TownManger.Domain.Concrete
{
    public class EFDbContext:DbContext
    {
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}
        public DbSet<Resdient> Resdients { get; set; }
        public  DbSet<Family> Families { get; set; }
        public  DbSet<Floor> Floors { get; set; }
        public  DbSet<Unit> Units { get; set; }
        public  DbSet<FamilyMem> FamilyMems { get; set; }
        public  DbSet<Visitor> Visitors { get; set; }
        public DbSet<Building> Buildings { get; set; }


    }
}
