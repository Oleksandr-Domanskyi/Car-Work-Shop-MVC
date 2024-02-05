using CarWorkShop.Application.CarWorkShop.DataTranferObject;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Application.Commands.CreateCarWorkShop
{
    public class CreateCarWorkShopCommand :  CarWorkShopObject,IRequest
    {
    }
}
