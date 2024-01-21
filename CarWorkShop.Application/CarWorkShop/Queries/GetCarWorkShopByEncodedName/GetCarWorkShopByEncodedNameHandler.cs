using AutoMapper;
using CarWorkShop.Application.DataTranferObject;
using CarWorkShop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Application.CarWorkShop.Queries.GetCarWorkShopByEncodedName
{
    public class GetCarWorkShopByEncodedNameHandler : IRequestHandler<GetCarWorkShopByEncodedNameQuery, CarWorkShopObject>
    {
        private readonly ICarWorkShopRepository _carWorkShopRepository;
        private readonly IMapper _mapper;

        public GetCarWorkShopByEncodedNameHandler(ICarWorkShopRepository carWorkShopRepository,IMapper mapper)
        {
            _carWorkShopRepository = carWorkShopRepository;
            _mapper = mapper;
        }
        public async Task<CarWorkShopObject> Handle(GetCarWorkShopByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var CarWorkShop = await _carWorkShopRepository.GetByEncodedName(request.EncodedName);
            var dto = _mapper.Map<CarWorkShopObject>(CarWorkShop);

            return dto;
        }
    }
}
