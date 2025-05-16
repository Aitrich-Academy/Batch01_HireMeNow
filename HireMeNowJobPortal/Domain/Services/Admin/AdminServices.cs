using AutoMapper;
using Domain.Models;
using Domain.Services.Admin.DTOs;
using Domain.Services.Admin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Admin
{
    public class AdminServices:IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public AdminServices(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        public async Task<IndustryDTOAdmin> AddIndustry(Industry industry)
        {
            var result = await _adminRepository.AddIndustry(industry);
            return _mapper.Map<IndustryDTOAdmin>(result);
        }

        public async Task<JobCategoryDTOAdmin> AddJobCategory(JobCategory jobCategory)
        {
            var result = await _adminRepository.AddJobCategory(jobCategory);
            return _mapper.Map<JobCategoryDTOAdmin>(result);
        }

        public async Task<LocationDTOAdmin> AddLocation(Location location)
        {
            var result = await _adminRepository.AddLocation(location);
            return _mapper.Map<LocationDTOAdmin>(result);
        }

        public async Task<SkillDTOAdmin> AddSkill(Skill skill)
        {
            var result = await _adminRepository.AddSkill(skill);
            return _mapper.Map<SkillDTOAdmin>(result);
        }

        public async Task<List<JobPostDTOAdmin>> GetAllJobPosts()
        {
            var jobPosts = await _adminRepository.GetAllJobPosts(); 
            return _mapper.Map<List<JobPostDTOAdmin>>(jobPosts);
        }

        public async Task<List<JobProviderCompanyDTOAdmin>> GetAllJobProviderCompanies()
        {
            var jobProviderCompanies = await _adminRepository.GetAllJobProviderCompanies();
            return _mapper.Map<List<JobProviderCompanyDTOAdmin>>(jobProviderCompanies);
        }

        public async Task<CompanyUserDTOAdmin> GetCompanyUserById(Guid companyUserId)
        {
            var user = await _adminRepository.GetCompanyUserById(companyUserId);

            if (user == null)
            {
                return null; 
            }

            return _mapper.Map<CompanyUserDTOAdmin>(user);
        }

        public int GetCompanyUserCount()
        {
            return _adminRepository.GetCompanyUserCount();
        }

        public async Task<List<CompanyUserDTOAdmin>> GetCompanyUsers()
        {
            var companyUsers = await _adminRepository.GetCompanyUsers();
            return _mapper.Map<List<CompanyUserDTOAdmin>>(companyUsers);
        }

        public async Task<List<IndustryDTOAdmin>> GetIndustries()
        {
            var industries = await _adminRepository.GetIndustries();
            return _mapper.Map<List<IndustryDTOAdmin>>(industries);
        }

        public async Task<IndustryDTOAdmin> GetIndustryById(Guid IndustryId)
        {
            var industry = await _adminRepository.GetIndustryById(IndustryId);

            if (industry == null)
            {
                return null;
            }

            return _mapper.Map<IndustryDTOAdmin>(industry);
        }

        public async Task<List<JobCategoryDTOAdmin>> GetJobCategories()
        {
            var categories = await _adminRepository.GetJobCategories();
            return _mapper.Map<List<JobCategoryDTOAdmin>>(categories);
        }

        public async Task<JobCategoryDTOAdmin> GetJobCategoryById(Guid jobCategoryId)
        {
            var category = await _adminRepository.GetJobCategoryById(jobCategoryId);

            if (category == null)
            {
                return null;
            }

            return _mapper.Map<JobCategoryDTOAdmin>(category);
        }

        public int GetJobPostCount()
        {
            return _adminRepository.GetJobPostCount();
        }

        public async Task<JobPostDTOAdmin> GetJobPostsById(Guid jobPostId)
        {
            var jobPost = await _adminRepository.GetJobPostsById(jobPostId);

            if (jobPost == null)
            {
                return null;
            }

            return _mapper.Map<JobPostDTOAdmin>(jobPost);
        }

        public async Task<List<JobPostDTOAdmin>> GetJobPostsByName(string jobTitle)
        {
            var jobPosts = await _adminRepository.GetJobPostsByName(jobTitle);

            if (jobPosts == null || !jobPosts.Any())
            {
                return new List<JobPostDTOAdmin>(); 
            }

            return _mapper.Map<List<JobPostDTOAdmin>>(jobPosts);
        }

        public async Task<JobProviderCompanyDTOAdmin> GetJobProviderCompanyById(Guid jobProviderCompanyId)
        {
            var jobProviderCompany = await _adminRepository.GetJobProviderCompanyById(jobProviderCompanyId);

            if (jobProviderCompany == null)
            {
                return null;
            }

            return _mapper.Map<JobProviderCompanyDTOAdmin>(jobProviderCompany);
        }

        public int GetJobProviderCompanyCount()
        {
            return _adminRepository.GetJobProviderCompanyCount();
        }

        public async Task<JobSeekerDTOAdmin> GetJobSeekerById(Guid jobSeekerId)
        {
            var jobSeeker = await _adminRepository.GetJobSeekerById(jobSeekerId);

            if (jobSeeker == null)
            {
                return null;
            }

            return _mapper.Map<JobSeekerDTOAdmin>(jobSeeker);
        }

        public int GetJobSeekerCount()
        {
            return _adminRepository.GetJobSeekerCount();
        }

        public async Task<List<JobSeekerDTOAdmin>> GetJobSeekers()
        {
            var jobSeekers = await _adminRepository.GetJobSeekers();
            return _mapper.Map<List<JobSeekerDTOAdmin>>(jobSeekers);
        }

        public async Task<LocationDTOAdmin> GetLocationById(Guid locationId)
        {
            var location = await _adminRepository.GetLocationById(locationId);

            if (location == null)
            {
                return null;
            }

            return _mapper.Map<LocationDTOAdmin>(location);
        }

        public async Task<List<LocationDTOAdmin>> GetLocations()
        {
            var locations = await _adminRepository.GetLocations();
            return _mapper.Map<List<LocationDTOAdmin>>(locations);
        }

        public async Task<List<SkillDTOAdmin>> GetSkills()
        {
            var skills = await _adminRepository.GetSkills();
            return _mapper.Map<List<SkillDTOAdmin>>(skills);
        }

        public async Task<SkillDTOAdmin> GetSkillsById(Guid skillId)
        {
            var skill = await _adminRepository.GetSkillsById(skillId);

            if (skill == null)
            {
                return null;
            }

            return _mapper.Map<SkillDTOAdmin>(skill);
        }

        public async Task<IndustryDTOAdmin> RemoveIndustryById(Guid industryId)
        {
            var deletedIndustry = await _adminRepository.RemoveIndustryById(industryId);

            if (deletedIndustry == null)
            {
                return null;
            }

            return _mapper.Map<IndustryDTOAdmin>(deletedIndustry);
        }

        public async Task<JobCategoryDTOAdmin> RemoveJobCategoryById(Guid jobCategoryId)
        {
            var deletedCategory = await _adminRepository.RemoveJobCategoryById(jobCategoryId);

            if (deletedCategory == null)
            {
                return null;
            }

            return _mapper.Map<JobCategoryDTOAdmin>(deletedCategory);
        }

        public async Task<LocationDTOAdmin> RemoveLocationById(Guid locationId)
        {
            var deletedLocation = await _adminRepository.RemoveLocationById(locationId);

            if (deletedLocation == null)
            {
                return null; 
            }

            return _mapper.Map<LocationDTOAdmin>(deletedLocation);
        }

        public async Task<SkillDTOAdmin> RemoveSkillById(Guid skillId)
        {
            var deletedSkill = await _adminRepository.RemoveSkillById(skillId);

            if (deletedSkill == null)
            {
                return null;
            }

            return _mapper.Map<SkillDTOAdmin>(deletedSkill);
        }

        public async Task<List<JobProviderCompanyDTOAdmin>> SearchJobProviderCompanyByName(string name)
        {
            var companies = await _adminRepository.SearchJobProviderCompanyByName(name);

            if (companies == null || !companies.Any())
            {
                return new List<JobProviderCompanyDTOAdmin>();
            }

            return _mapper.Map<List<JobProviderCompanyDTOAdmin>>(companies);
        }

        public async Task<IndustryDTOAdmin> UpdateIndustry(Industry updatedIndustry, Guid industryId)
        {
            var updatedEntity = await _adminRepository.UpdateIndustry(updatedIndustry, industryId);

            if (updatedEntity == null)
            {
                return null; 
            }

            return _mapper.Map<IndustryDTOAdmin>(updatedEntity);
        }

        public async Task<JobCategoryDTOAdmin> UpdateJobCategory(JobCategory updatedJobCategory, Guid jobCategoryId)
        {
            var updatedEntity = await _adminRepository.UpdateJobCategory(updatedJobCategory, jobCategoryId);

            if (updatedEntity == null)
            {
                return null;
            }

            return _mapper.Map<JobCategoryDTOAdmin>(updatedEntity);
        }

        public async Task<LocationDTOAdmin> UpdateLocation(Location updatedLocation, Guid locationId)
        {
            var updatedEntity = await _adminRepository.UpdateLocation(updatedLocation, locationId);

            if (updatedEntity == null)
            {
                return null;
            }

            return _mapper.Map<LocationDTOAdmin>(updatedEntity);
        }

        public async Task<SkillDTOAdmin> UpdateSkill(Skill updatedSkill, Guid skillId)
        {
            var updatedEntity = await _adminRepository.UpdateSkill(updatedSkill, skillId);

            if (updatedEntity == null)
            {
                return null;
            }

            return _mapper.Map<SkillDTOAdmin>(updatedEntity);
        }
    }
}
