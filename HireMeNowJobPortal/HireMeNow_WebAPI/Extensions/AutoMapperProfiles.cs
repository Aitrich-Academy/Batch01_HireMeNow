using AutoMapper;
using Domain.Models;
using Domain.Service.JobProvider.Dtos;
using Domain.Service.JobProvider.DTOs;
using Domain.Service.SignUp.DTOs;
using Domain.Services.Admin.DTOs;
using Domain.Services.Authuser.DTOs;
using Domain.Services.JobProvider.DTOs;
using Domain.Services.JobSeeker.Job.DTO;
using Domain.Services.JobSeeker.JobSeekerProfile.DTO;
using Domain.Services.Login.DTO;
using Domain.Services.Login.DTOs;
using Domain.Services.SignUp.DTO;
using HireMeNow_WebApi.API.JobProvider.RequestObjects;
using HireMeNow_WebAPI.API.Admin.RequestObjects;
using HireMeNow_WebAPI.API.JobSeeker.Job.DTO;
using HireMeNow_WebAPI.API.JobSeeker.JobSeekerCredentials.Requests;


namespace HireMeNow_WebAPI.Extensions
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            //Admin***************************************************

            CreateMap<AuthUser, AdminLoginDTO>();

            CreateMap<Domain.Models.JobSeeker, JobSeekerDTOAdmin>().ReverseMap();

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

            //JobSeeker***********************************************

            CreateMap<JobSeekerSignUpRequestDTO, SignUpRequest>().ReverseMap();
            CreateMap<JobSeekerSignUpRequest, JobSeekerSignUpRequestDTO>().ReverseMap();
            CreateMap<AuthUser, AuthUserDTO>().ReverseMap();
            CreateMap<SignUpRequest, SystemUser>().ReverseMap();
            CreateMap<AuthUser, JobSeeker>().ReverseMap();
            CreateMap<AuthUser, SystemUser>().ReverseMap();
            CreateMap<AuthUser, LoginDTO>().ReverseMap();
            CreateMap<JobPostDTO, JobPost>().ReverseMap();
            CreateMap<JobPost, JobPostDTO>()
                      .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location.Name))
                      .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.LegalName))
                      .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.JobCategory.Name))
                      .ForMember(dest => dest.IndustryName, opt => opt.MapFrom(src => src.Industry.Name));
            CreateMap<JobApplicationDTO, JobApplication>().ReverseMap();
            CreateMap<SavedJobDTO, SavedJob>().ReverseMap();
            CreateMap<JobSeekerProfile, JobSeekerProfileDTO>().ReverseMap();
            CreateMap<JobSeekerProfileUpdateDTO, JobSeekerProfile>().ReverseMap();
            CreateMap<ResumeDTO, Resume>().ReverseMap();
            CreateMap<JobSeekerSkillDTO, JobSeekerProfileSkill>().ReverseMap();
            CreateMap<JobSeekerExperienceDTO, WorkExperience>().ReverseMap();
            CreateMap<JobSeekerQualificationDTO, Qualification>().ReverseMap();
            CreateMap<QualificationDTO, JobSeekerQualificationDTO>().ReverseMap();
            CreateMap<QualificationDTO, UpdateQualificationDTO>().ReverseMap();
            CreateMap<QualificationDTO, Qualification>().ReverseMap();
            CreateMap<UpdateQualificationDTO, Qualification>().ReverseMap();
            CreateMap<InterviewDTO, Interview>().ReverseMap();
            CreateMap<Resume, ResumeViewDTO>().ReverseMap();


            //***************************************************************************

            //JOB PROVIDER*******************************************************************

            CreateMap<CompanyMemberDtos, CompanyUser>().ReverseMap();
            CreateMap<companyUserRequest, CompanyMemberDtos>().ReverseMap();

            CreateMap<CompanyMemberDtos, AuthUser>().ReverseMap();
            CreateMap<JobPostRequest, JobPost>().ReverseMap();

            CreateMap<JobApplication, JobApplicationDto>().ReverseMap();


            CreateMap<CompanyRegistrationDtos, JobProviderCompany>().ReverseMap();
            CreateMap<AddCompanyRequestobject, JobProviderCompany>().ReverseMap();
            CreateMap<CompanyRegistrationDtos, AddCompanyRequestobject>().ReverseMap();
            CreateMap<CompanyUpdateDtos, CompanyupdateRequest>().ReverseMap();
            CreateMap<CompanyUpdateDtos, JobProviderCompany>().ReverseMap();

            CreateMap<JobProviderCompany, GetCompanyDetailsDto>();
            CreateMap<InterviewSheduleObject, InterviewsheduleDtos>();
            CreateMap<InterviewsheduleDtos, Interview>();
            CreateMap<SheduledInterviewDto, Interview>();
            CreateMap<Interview, SheduledInterviewDto>();
            CreateMap<CompanyUser, CompanyMemberListDtos>().ReverseMap();


            CreateMap<JobProviderSignupRequestDto, SignUpRequest>().ReverseMap();
            CreateMap<JobProviderSignupRequest, JobProviderSignupRequestDto>().ReverseMap();
            CreateMap<JobPost, JobProviderDto>().ReverseMap();
            CreateMap<SignUpRequest, SystemUser>().ReverseMap();
            CreateMap<JobProviderCompany, JobProviderDto>().ReverseMap();
            CreateMap<JobPost, JobPostProviderDto>().ReverseMap();
            CreateMap<AuthUser, SystemUser>().ReverseMap();
            CreateMap<AuthUser, Domain.Models.CompanyUser>().ReverseMap();
            CreateMap<AuthUser, LoginDTO>().ReverseMap();
            CreateMap<Industry, ProviderIndustryDto>().ReverseMap();

            //****************************************************************************


        }
    }
}
