using CarWorkShop.Application.DataTranferObject;
using CarWorkShop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Application.Commands.Queries.GetAllCarWorkShops
{
    public class GetAllCarWorkShopsQuery:IRequest<IEnumerable<CarWorkShopObject>>
    {
    }
}
