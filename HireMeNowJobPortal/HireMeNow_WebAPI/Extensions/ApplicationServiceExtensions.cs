using Domain.Models;
using Domain.Services.AuthUser.Interfaces;
using Domain.Services.AuthUser;

using Microsoft.EntityFrameworkCore;

namespace HireMeNow_WebAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbHireMeNowWebApiContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            return services;
        }
    }
}
