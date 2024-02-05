using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Infrastructure.DataBase
{
    public class CarWorkShopDbContext: IdentityDbContext
    {
        public CarWorkShopDbContext(DbContextOptions<CarWorkShopDbContext>options):base(options)
        {
            
        }
        public DbSet<Domain.Entities.CarWorkShop>CarWorkShops { get; set; }
        public DbSet<Domain.Entities.CarWorkShopService> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Domain.Entities.CarWorkShop>()
                .OwnsOne(c => c.ContactDetails);

            modelBuilder.Entity<Domain.Entities.CarWorkShop>()
                .HasMany(c => c.Services)
                .WithOne(s => s.CarWorkShop)
                .HasForeignKey(s => s.CarWorkShopId);
        }

    }
}
