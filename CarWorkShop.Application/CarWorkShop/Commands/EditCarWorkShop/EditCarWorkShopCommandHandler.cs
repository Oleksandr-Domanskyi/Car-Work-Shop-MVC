using AutoMapper;
using CarWorkShop.Application.ApplicationUser;
using CarWorkShop.Application.DataTranferObject;

using CarWorkShop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Application.CarWorkShop.Commands.EditCarWorkShop
{
    public class EditCarWorkShopCommandHandler : IRequestHandler<EditCarWorkShopCommand>
    {
        private readonly ICarWorkShopRepository _carWorkShopRepository;
        private readonly IUserContext _userContext;

        public EditCarWorkShopCommandHandler(ICarWorkShopRepository carWorkShopRepository,IUserContext userContext)
        {
            _carWorkShopRepository = carWorkShopRepository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(EditCarWorkShopCommand request, CancellationToken cancellationToken)
        {
            var CarWorkShop = await _carWorkShopRepository.GetByEncodedName(request.EncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user!=null && CarWorkShop?.CreatedById == user.Id;

            if(!isEditable)
            {
                return Unit.Value;
            }

            CarWorkShop!.Description= request.Description;
            CarWorkShop.About= request.About;

            CarWorkShop.ContactDetails.PhoneNumber = request.PhoneNumber;
            CarWorkShop.ContactDetails.Street = request.Street;
            CarWorkShop.ContactDetails.City = request.City;
            CarWorkShop.ContactDetails.PostalCode = request.PostalCode;

            await _carWorkShopRepository.Commit();

            return Unit.Value;

        }
    }
}
