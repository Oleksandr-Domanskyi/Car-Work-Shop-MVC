using AutoMapper;
using CarWorkShop.Application.DataTranferObject;
using CarWorkShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Application.Services
{
    public class CarWorkShopService : ICarWorkShopService
    {
        private readonly ICarWorkShopRepository _carWorkShopRepository;
        private readonly IMapper _mapper;

        public CarWorkShopService(ICarWorkShopRepository carWorkShopRepository,IMapper mapper)
        {
            _carWorkShopRepository = carWorkShopRepository;
            _mapper = mapper;
        }
        public async Task Create(CarWorkShopObject carWorkShopDto)
        {
            var carWorkShop = _mapper.Map<Domain.Entities.CarWorkShop>(carWorkShopDto);
            carWorkShop.EncodeName();
            await _carWorkShopRepository.Create(carWorkShop);
        }
    }
}
