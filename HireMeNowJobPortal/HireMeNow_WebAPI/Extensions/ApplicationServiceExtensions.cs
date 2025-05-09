using Domain.Models;
using Domain.Services.AuthUser.Interfaces;
using Domain.Services.AuthUser;

using Microsoft.EntityFrameworkCore;
using Domain.Services.Login.Interfaces;
using Domain.Services.Login;

namespace HireMeNow_WebAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbHireMeNowWebApiContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddScoped<IAuthUserRepository, AuthUserRepository>();
            services.AddScoped<IAuthUserService, AuthUserService>();
            services.AddHttpContextAccessor();

            services.AddScoped<ILoginRequestService, LoginRequestService>();
            services.AddScoped<ILoginRequestRepository, LoginRequestRepository>();

            return services;
        }
    }
}
