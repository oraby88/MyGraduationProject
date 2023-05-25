using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using projectMVC.Models;
namespace projectMVC.Models
{
    public partial class projectDbContext : DbContext
    {
        public DbSet<Admin> Admines { get; set; }
        public DbSet<Employe> Employies { get; set; }
        public DbSet<Food> Foodies { get; set; }
        public DbSet<Drink> Drinkies { get; set; }
        public DbSet<Seet> Seets { get; set; }
   
        public DbSet<Casher> Cashers { get; set; }

        public projectDbContext()
            : base("name=projectDbContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
