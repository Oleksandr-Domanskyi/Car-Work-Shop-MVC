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
    }
}
