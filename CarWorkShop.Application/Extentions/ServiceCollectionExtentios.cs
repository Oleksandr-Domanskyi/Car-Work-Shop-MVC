using CarWorkShop.Application.DataTranferObject;
using CarWorkShop.Application.Mapping;
using CarWorkShop.Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Application.Extentions
{
    public static class ServiceCollectionExtentios
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICarWorkShopService, CarWorkShopService>();

            services.AddAutoMapper(typeof(CarWorkShopMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CarWorkShopValidationObject>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
