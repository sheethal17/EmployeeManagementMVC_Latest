using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MVCemployemanage.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        
        public virtual DbSet<emptable> emplo { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<emptable>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<emptable>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<emptable>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<emptable>()
                .Property(e => e.gender)
                .IsUnicode(false);

            modelBuilder.Entity<emptable>()
                .Property(e => e.password)
                .IsUnicode(false);


        }












    }
}
