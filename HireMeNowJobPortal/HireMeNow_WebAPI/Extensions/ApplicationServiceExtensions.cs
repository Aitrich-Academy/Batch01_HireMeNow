using Domain.Models;
using Domain.Services.AuthUser.Interfaces;
using Domain.Services.AuthUser;

using Microsoft.EntityFrameworkCore;
using Domain.Services.Login.Interfaces;
using Domain.Services.Login;
using Domain.Services.Admin.Interfaces;
using Domain.Services.Admin;
using NETCore.MailKit.Core;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using Domain.Services.SignUp.Interfaces;
using Domain.Services.SignUp;
using Domain.Services.JobSeeker.Job.Interfaces;
using Domain.Services.JobSeeker.Job;
using Domain.Services.JobSeeker.JobSeekerProfile.Interfaces;
using Domain.Services.JobSeeker.JobSeekerProfile;

using Domain.Services.JobProvider.Interfaces;
using Domain.Services.JobProvider;

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

            //Admin************************************************

            services.AddScoped<IAdminService, AdminServices>();
            services.AddScoped<IAdminRepository, AdminRepository>();

            //*****************************************************

            //JobSeeker*******************************************
            services.AddMailKit(config =>
            {
                config.UseMailKit(new MailKitOptions()
                {
                    Server = configuration["MailSettings:Host"],
                    Port = int.Parse(configuration["MailSettings:Port"]),
                    SenderName = configuration["MailSettings:DisplayName"],
                    SenderEmail = configuration["MailSettings:UserMail"],
                    Account = configuration["MailSettings:UserMail"],
                    Password = configuration["MailSettings:Password"],
                    Security = configuration.GetValue<bool>("MailSettings:UseSSL")
                        ? true : false
                });
            });

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ISignUpRequestRepository, SignUpRepository>();
            services.AddScoped<ISignUpRequestService, SignUpService>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IJobSeekerProfileRepository, JobSeekerProfileRepository>();
            services.AddScoped<IJobSeekerService, JobSeekerProfileService>();

            //**************************************************************


            //JOB PROVIDER****************************************************

    


            services.AddScoped<ICompanyService, Companyservice>();
            services.AddScoped<ICompanyRepository, Companyrepository>();

            services.AddScoped<IInterviewService, InterviewService>();
            services.AddScoped<IInterviewRepository, InterviewRepository>();

            services.AddScoped<IJobProviderService, JobProviderService>();
            services.AddScoped<IJobProviderRepository, JobProviderRepository>();

            services.AddTransient<Domain.Services.IEmailService, Domain.Services.EmailService>();



            //****************************************************************

            return services;
        }
    }
}
