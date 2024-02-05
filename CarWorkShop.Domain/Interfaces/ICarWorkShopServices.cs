using CarWorkShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Domain.Interfaces
{
    public interface ICarWorkShopServicesRepository
    {
        Task Create(CarWorkShopService carWorkShopService);
    }
}
