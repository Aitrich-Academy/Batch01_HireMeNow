using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Admin.Interfaces
{
    public interface IAdminRepository
    {
         Task<List<JobSeeker>> GetJobSeekers();
         Task<JobSeeker> GetJobSeekerById(Guid jobSeekerId);
         int GetJobSeekerCount();
         Task<List<JobProviderCompany>> GetAllJobProviderCompanies();
         Task<JobProviderCompany> GetJobProviderCompanyById(Guid jobProviderCompanyId);
         int GetJobProviderCompanyCount();
         Task<List<JobProviderCompany>> SearchJobProviderCompanyByName(string name);
         Task<List<CompanyUser>> GetCompanyUsers();
         Task<CompanyUser> GetCompanyUserById(Guid companyUserId);
         int GetCompanyUserCount();
         Task<List<JobPost>> GetAllJobPosts();
         Task<JobPost> GetJobPostsById(Guid jobPostId);
         int GetJobPostCount();
         Task<List<JobPost>> GetJobPostsByName(string jobTitle);
         Task<List<Location>> GetLocations();
         Task<Location> GetLocationById(Guid locationId);
         Task<Location> AddLocation(Location location);
         Task<Location> UpdateLocation(Location updatedLocation, Guid locationId);
         Task<Location> RemoveLocationById(Guid locationId);
         Task<List<Skill>> GetSkills();
         Task<Skill> GetSkillsById(Guid skillId);
         Task<Skill> AddSkill(Skill skill);
         Task<Skill> UpdateSkill(Skill updatedSkill, Guid skillId);
         Task<Skill> RemoveSkillById(Guid skillId);
         Task<List<Industry>> GetIndustries();
         Task<Industry> GetIndustryById(Guid IndustryId);
         Task<Industry> AddIndustry(Industry industry);
         Task<Industry> UpdateIndustry(Industry updatedIndustry, Guid industryId);
         Task<Industry> RemoveIndustryById(Guid industryId);
         Task<List<JobCategory>> GetJobCategories();
         Task<JobCategory> GetJobCategoryById(Guid jobCategoryId);
         Task<JobCategory> AddJobCategory(JobCategory jobCategory);
         Task<JobCategory> UpdateJobCategory(JobCategory updatedJobCategory, Guid jobCategoryId);
         Task<JobCategory> RemoveJobCategoryById(Guid jobCategoryId);
    }
}
