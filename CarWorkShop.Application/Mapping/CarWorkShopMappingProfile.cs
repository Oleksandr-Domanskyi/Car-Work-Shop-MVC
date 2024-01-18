using AutoMapper;
using CarWorkShop.Application.DataTranferObject;
using CarWorkShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Application.Mapping
{
    public class CarWorkShopMappingProfile:Profile
    {
        public CarWorkShopMappingProfile()
        {
            CreateMap<CarWorkShopObject, Domain.Entities.CarWorkShop>()
                .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new CarWorkShopContactDetails()
                {
                    City = src.City,
                    PhoneNumber = src.PhoneNumber,
                    PostalCode = src.PostalCode,
                    Street = src.Street
                }));
        }
    }
}
