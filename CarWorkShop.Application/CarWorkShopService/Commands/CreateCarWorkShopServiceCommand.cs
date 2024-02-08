using CarWorkShop.Application.CarWorkShopService.DataTransferObject;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Application.CarWorkShopService.Commands
{
    public class CreateCarWorkShopServiceCommand:CarWorkShopServiceObject,IRequest
    {
        public string CarWorkShopEncodedName { get; set; } = default!;
    }
}
