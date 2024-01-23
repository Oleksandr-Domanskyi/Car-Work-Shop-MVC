using CarWorkShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Domain.Interfaces
{
    public interface ICarWorkShopRepository
    {
        Task Create(Domain.Entities.CarWorkShop carWorkShop);
        Task<Domain.Entities.CarWorkShop?> GetByName(string name);
        Task<IEnumerable<Domain.Entities.CarWorkShop?>> GetAll();
        Task<Domain.Entities.CarWorkShop?> GetByEncodedName(string encodedName);
        Task Commit();

    }
}
