using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class MyDbContext : DbContext
    {
        public DbSet<Area> Areas { get; set; }

        public DbSet<PerfilesdeCargo> PerfilesdeCargo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<PerfilesdeCargo>().HasMany(p => p.Area).WithMany(a=>a.PerfildeCargo);
            modelBuilder.Entity<Area>().HasMany(a => a.PerfildeCargo).WithMany(p=>p.Area);

        }

    }
}
