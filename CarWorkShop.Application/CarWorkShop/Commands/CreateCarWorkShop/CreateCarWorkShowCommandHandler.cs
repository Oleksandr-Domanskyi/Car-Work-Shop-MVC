using AutoMapper;
using CarWorkShop.Application.ApplicationUser;
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
        private readonly IUserContext _userContext;

        public CreateCarWorkShowCommandHandler(ICarWorkShopRepository carWorkShopRepository,IMapper mapper,IUserContext userContext)
        {
            _carWorkShopRepository = carWorkShopRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreateCarWorkShopCommand request, CancellationToken cancellationToken)
        {
            var carWorkShop = _mapper.Map<Domain.Entities.CarWorkShop>(request);
            carWorkShop.EncodeName();

            carWorkShop.CreatedById = _userContext.GetCurrentUser()?.Id;

            await _carWorkShopRepository.Create(carWorkShop);

            return Unit.Value;
        }
    }
}
