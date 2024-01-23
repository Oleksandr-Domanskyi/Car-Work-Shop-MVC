using AutoMapper;
using CarWorkShop.Application.CarWorkShop.Commands.EditCarWorkShop;
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

            CreateMap<Domain.Entities.CarWorkShop,CarWorkShopObject>()
                .ForMember(dto=>dto.Street,opt=>opt.MapFrom(src=> src.ContactDetails.Street))
                .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.ContactDetails.City))
                .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber))
                .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode));

            CreateMap<CarWorkShopObject, EditCarWorkShopCommand>();

        }
    }
}
