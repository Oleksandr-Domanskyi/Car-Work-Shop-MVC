using CarWorkShop.Domain.Interfaces;
using CarWorkShop.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Domain.Entities.CarWorkShop?>> GetAll()
            => await _dbContext.CarWorkShops.ToListAsync();

        public async Task<Domain.Entities.CarWorkShop?> GetByEncodedName(string encodedName)
            => await _dbContext.CarWorkShops.FirstOrDefaultAsync(r => r.EncodedName == encodedName);
        public async Task<Domain.Entities.CarWorkShop?> GetByName(string name)
            => await _dbContext.CarWorkShops.FirstOrDefaultAsync(r => r.Name.ToLower() == name.ToLower());
    }
}
