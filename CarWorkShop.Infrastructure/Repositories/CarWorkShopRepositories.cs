using CarWorkShop.Domain.Interfaces;
using CarWorkShop.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Infrastructure.Repositories
{
    internal class CarWorkShopRepositories : ICarWorkShopRepository
    {
        private readonly CarWorkShopDbContext _dbContext;

        public CarWorkShopRepositories(CarWorkShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Domain.Entities.CarWorkShop carWorkShop)
        {
            await _dbContext.AddAsync(carWorkShop);
            await _dbContext.SaveChangesAsync();
        }
    }
}
