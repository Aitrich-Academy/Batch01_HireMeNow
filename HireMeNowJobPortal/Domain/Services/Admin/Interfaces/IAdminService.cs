using Domain.Models;
using Domain.Services.Admin.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Admin.Interfaces
{
    public interface IAdminService
    {
        Task<List<JobSeekerDTOAdmin>> GetJobSeekers();
        Task<JobSeekerDTOAdmin> GetJobSeekerById(Guid jobSeekerId);
        int GetJobSeekerCount();
        Task<List<JobProviderCompanyDTOAdmin>> GetAllJobProviderCompanies();
        Task<JobProviderCompanyDTOAdmin> GetJobProviderCompanyById(Guid jobProviderCompanyId);
        int GetJobProviderCompanyCount();
        Task<List<JobProviderCompanyDTOAdmin>> SearchJobProviderCompanyByName(string name);
        Task<List<CompanyUserDTOAdmin>> GetCompanyUsers();
        Task<CompanyUserDTOAdmin> GetCompanyUserById(Guid companyUserId);
        int GetCompanyUserCount();
        Task<List<JobPostDTOAdmin>> GetAllJobPosts();
        Task<JobPostDTOAdmin> GetJobPostsById(Guid jobPostId);
        int GetJobPostCount();
        Task<List<JobPostDTOAdmin>> GetJobPostsByName(string jobTitle);
        Task<List<LocationDTOAdmin>> GetLocations();
        Task<LocationDTOAdmin> GetLocationById(Guid locationId);
        Task<LocationDTOAdmin> AddLocation(Location location);
        Task<LocationDTOAdmin> UpdateLocation(Location updatedLocation, Guid locationId);
        Task<LocationDTOAdmin> RemoveLocationById(Guid locationId);
        Task<List<SkillDTOAdmin>> GetSkills();
        Task<SkillDTOAdmin> GetSkillsById(Guid skillId);
        Task<SkillDTOAdmin> AddSkill(Skill skill);
        Task<SkillDTOAdmin> UpdateSkill(Skill updatedSkill, Guid skillId);
        Task<SkillDTOAdmin> RemoveSkillById(Guid skillId);
        Task<List<IndustryDTOAdmin>> GetIndustries();
        Task<IndustryDTOAdmin> GetIndustryById(Guid IndustryId);
        Task<IndustryDTOAdmin> AddIndustry(Industry industry);
        Task<IndustryDTOAdmin> UpdateIndustry(Industry updatedIndustry, Guid industryId);
        Task<IndustryDTOAdmin> RemoveIndustryById(Guid industryId);
        Task<List<JobCategoryDTOAdmin>> GetJobCategories();
        Task<JobCategoryDTOAdmin> GetJobCategoryById(Guid jobCategoryId);
        Task<JobCategoryDTOAdmin> AddJobCategory(JobCategory jobCategory);
        Task<JobCategoryDTOAdmin> UpdateJobCategory(JobCategory updatedJobCategory, Guid jobCategoryId);
        Task<JobCategoryDTOAdmin> RemoveJobCategoryById(Guid jobCategoryId);
    }
}
