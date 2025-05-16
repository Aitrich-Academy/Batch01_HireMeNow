using AutoMapper;
using Domain.Models;
using Domain.Services.Admin.DTOs;
using Domain.Services.Login.DTOs;
using HireMeNow_WebAPI.API.Admin.RequestObjects;


namespace HireMeNow_WebAPI.Extensions
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            //Admin***************************************************

            CreateMap<AuthUser, AdminLoginDTO>();

            CreateMap<JobSeeker, JobSeekerDTOAdmin>().ReverseMap();

            CreateMap<JobProviderCompany, JobProviderCompanyDTOAdmin>()
                     .ForMember(dest => dest.IndustryName,
                                opt => opt.MapFrom(src => src.Industry != null ? src.Industry.Name : null))
                     .ForMember(dest => dest.LocationName,
                                opt => opt.MapFrom(src => src.LocationNavigation != null ? src.LocationNavigation.Name : null));

            CreateMap<CompanyUser, CompanyUserDTOAdmin>()
                     .ForMember(dest => dest.CompanyName,
                                opt => opt.MapFrom(src => src.CompanyNavigation != null ? src.CompanyNavigation.LegalName : null));

            CreateMap<JobPost, JobPostDTOAdmin>()
                     .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location != null ? src.Location.Name : null))
                     .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company != null ? src.Company.LegalName : null))
                     .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.JobCategory != null ? src.JobCategory.Name : null))
                     .ForMember(dest => dest.IndustryName, opt => opt.MapFrom(src => src.Industry != null ? src.Industry.Name : null))
                     .ForMember(dest => dest.PostedByName, opt => opt.MapFrom(src => src.PostedByNavigation != null ? src.PostedByNavigation.FirstName : null));

            CreateMap<Location, LocationDTOAdmin>().ReverseMap();
            CreateMap<Skill, SkillDTOAdmin>().ReverseMap();
            CreateMap<Industry, IndustryDTOAdmin>().ReverseMap();
            CreateMap<JobCategory, JobCategoryDTOAdmin>().ReverseMap();

            CreateMap<LocationRequestAdmin, Location>();
            CreateMap<SkillRequestAdmin, Skill>();
            CreateMap<IndustryRequestAdmin, Industry>();
            CreateMap<JobCategoryRequestAdmin, JobCategory>();

            //**********************************************************
        }
    }
}
