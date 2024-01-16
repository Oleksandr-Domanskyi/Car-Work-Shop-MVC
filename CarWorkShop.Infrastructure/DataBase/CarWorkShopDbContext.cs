using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Infrastructure.DataBase
{
    public class CarWorkShopDbContext: DbContext
    {
        public CarWorkShopDbContext(DbContextOptions<CarWorkShopDbContext>options):base(options)
        {
            
        }
        public DbSet<Domain.Entities.CarWorkShop>CarWorkShops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.CarWorkShop>().OwnsOne(c => c.ContactDetails);
        }

    }
}
