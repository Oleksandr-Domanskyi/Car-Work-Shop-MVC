using AutoMapper;
using CarWorkShop.Application.CarWorkShop.DataTranferObject;
using CarWorkShop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Application.Commands.Queries.GetAllCarWorkShops
{

    public class GetAllCarWorkShopsQueryHandler:IRequestHandler<GetAllCarWorkShopsQuery,IEnumerable<CarWorkShopObject>>
    {
        private readonly ICarWorkShopRepository _carWorkShopRepository;
        private readonly IMapper _mapper;

        public GetAllCarWorkShopsQueryHandler(ICarWorkShopRepository carWorkShopRepository,IMapper mapper)
        {
            _carWorkShopRepository = carWorkShopRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CarWorkShopObject>> Handle(GetAllCarWorkShopsQuery request,CancellationToken cancellationToken)
        {
            var CarWorkShops = await _carWorkShopRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<CarWorkShopObject>>(CarWorkShops);

            return dtos;
        }
    }
}
