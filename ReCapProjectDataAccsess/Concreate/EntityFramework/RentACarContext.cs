using Microsoft.EntityFrameworkCore;
using ReCapProjectEntities.ConCreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProjectDataAccsess.Concreate.EntityFramework
{
    public class RentACarContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-VMT292V\SQLEXPRESS; Database=RentACar;User ID=sa;Password=134679fb;Integrated Security=false;");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }


    }
}
