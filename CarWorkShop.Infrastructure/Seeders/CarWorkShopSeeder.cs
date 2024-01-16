using CarWorkShop.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Infrastructure.Seeders
{
    public class CarWorkShopSeeder
    {
        private readonly CarWorkShopDbContext _dbContext;

        public CarWorkShopSeeder(CarWorkShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Seed()
        {
            if(await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.CarWorkShops.Any())
                {
                    var mazdaAso = new Domain.Entities.CarWorkShop()
                    { 
                        Id = Guid.Parse("44e7a512-d856-472f-8624-3f735b2bbe12"),
                        Name = "Mazda ASO",
                        Description = "Autoryzowany servis Mazda",
                        About = default,
                        ContactDetails = new Domain.Entities.CarWorkShopContactDetails() 
                        {
                            City = "Rzeszów",
                            PostalCode = "35-055",
                            Street="Naruszewicza",
                            PhoneNumber = "+48 XXX XXX XXX"
                        }
                    };
                    mazdaAso.EncodeName();
                    _dbContext.CarWorkShops.Add(mazdaAso);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
