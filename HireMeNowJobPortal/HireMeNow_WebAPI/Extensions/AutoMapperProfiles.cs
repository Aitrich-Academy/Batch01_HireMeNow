using AutoMapper;
using Domain.Models;
using Domain.Services.Login.DTOs;

namespace HireMeNow_WebAPI.Extensions
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AuthUser, AdminLoginDTO>();
        }
    }
}
