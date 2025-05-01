namespace HireMeNow_WebAPI.Extensions
{
    public class ApplicationServiceExtensions1
    {
<<<<<<< HEAD
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<NewDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;

        }
=======
>>>>>>> e2f68844080adf9a9031dc064156ce8a1a4394da
    }
}
