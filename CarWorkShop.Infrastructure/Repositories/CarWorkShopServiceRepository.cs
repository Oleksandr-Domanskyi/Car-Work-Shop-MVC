using CarWorkShop.Domain.Entities;
using CarWorkShop.Domain.Interfaces;
using CarWorkShop.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Infrastructure.Repositories
{
    public class CarWorkShopServiceRepository: ICarWorkShopServicesRepository
    {
        private readonly CarWorkShopDbContext _dbContext;

        public CarWorkShopServiceRepository(CarWorkShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(CarWorkShopService carWorkShopService)
        {
            _dbContext.Services.Add(carWorkShopService);
            await _dbContext.SaveChangesAsync();
        }
    }
}
