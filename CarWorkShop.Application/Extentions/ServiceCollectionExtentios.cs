using CarWorkShop.Application.Commands.CreateCarWorkShop;
using CarWorkShop.Application.Mapping;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
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
            services.AddMediatR(typeof(CreateCarWorkShopCommand));

            services.AddAutoMapper(typeof(CarWorkShopMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateCarWorkShopCommandValidatior>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
