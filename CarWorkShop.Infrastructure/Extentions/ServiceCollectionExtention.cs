using CarWorkShop.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkShop.Infrastructure.Extentions
{
    public static class ServiceCollectionExtention
    {
        public static void AddIfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<CarWorkShopDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CarWorkShopConnectionString")));
        }
    }
}
