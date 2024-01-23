using CarWorkShop.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Application.CarWorkShop.Commands.EditCarWorkShop
{
    public class EditCarWorkShopCommandValidator:AbstractValidator<EditCarWorkShopCommand>
    {
        public EditCarWorkShopCommandValidator(ICarWorkShopRepository carWorkShopRepository)
        {
            RuleFor(c => c.Description)
               .NotEmpty().WithMessage("Please Enter description");

            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
