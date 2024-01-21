using AutoMapper;
using CarWorkShop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Application.Commands.CreateCarWorkShop
{
    public class CreateCarWorkShowCommandHandler:IRequestHandler<CreateCarWorkShopCommand>
    {
        private readonly ICarWorkShopRepository _carWorkShopRepository;
        private readonly IMapper _mapper;

        public CreateCarWorkShowCommandHandler(ICarWorkShopRepository carWorkShopRepository,IMapper mapper)
        {
            _carWorkShopRepository = carWorkShopRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateCarWorkShopCommand request, CancellationToken cancellationToken)
        {
            var carWorkShop = _mapper.Map<Domain.Entities.CarWorkShop>(request);
            carWorkShop.EncodeName();

            await _carWorkShopRepository.Create(carWorkShop);

            return Unit.Value;
        }
    }
}
