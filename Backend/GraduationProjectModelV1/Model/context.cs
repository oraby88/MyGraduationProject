using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GraduationProjectModelV1.Model
{
    public partial class context : DbContext
    {
        public DbSet<Admin> Admines { get; set; }
        public DbSet<Employe> Employies { get; set; }
        public DbSet<Food> Foodies { get; set; }
        public DbSet<Drink> Drinkies { get; set; }
        public DbSet<Seet> Seets { get; set; }
        public DbSet<SingleSeet> SingleSeeties { get; set; }
        public DbSet<MultiSeet> MultiSeeties { get; set; }

        public context()
            : base("name=context")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
