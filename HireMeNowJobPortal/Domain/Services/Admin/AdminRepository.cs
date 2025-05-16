using Domain.Models;
using Domain.Services.Admin.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Admin
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DbHireMeNowWebApiContext _context;
        public AdminRepository(DbHireMeNowWebApiContext context)
        {
            _context = context;
        }
        public async Task<Industry> AddIndustry(Industry industry)
        {
            industry.Id = Guid.NewGuid();
            await _context.Industries.AddAsync(industry);

            await _context.SaveChangesAsync();

            return industry;
        }

        public async Task<JobCategory> AddJobCategory(JobCategory jobCategory)
        {
            jobCategory.Id = Guid.NewGuid();
            await _context.JobCategories.AddAsync(jobCategory);

            await _context.SaveChangesAsync();

            return jobCategory;
        }

        public async Task<Location> AddLocation(Location location)
        {
            location.Id = Guid.NewGuid();
            await _context.Locations.AddAsync(location);

            await _context.SaveChangesAsync();

            return location;
        }

        public async Task<Skill> AddSkill(Skill skill)
        {
            skill.Id = Guid.NewGuid();
            await _context.Skills.AddAsync(skill);

            await _context.SaveChangesAsync();

            return skill;
        }

        public async Task<List<JobPost>> GetAllJobPosts()
        {
            return await _context.JobPosts
                    .Include(j => j.Location)
                    .Include(j => j.Industry)
                    .Include(j => j.JobCategory)
                    .Include(j => j.PostedByNavigation)
                    .ToListAsync();
        }

        public async Task<List<JobProviderCompany>> GetAllJobProviderCompanies()
        {
            return await _context.JobProviderCompanies
                     .Include(j => j.LocationNavigation)
                     .Include(j => j.Industry)
                     .ToListAsync();
        }

        public async Task<CompanyUser> GetCompanyUserById(Guid companyUserId)
        {
            var companyUser = await  _context.CompanyUsers
                                             .Where(c => c.Id == companyUserId)
                                             .FirstOrDefaultAsync();

            return companyUser;
        }

        public int GetCompanyUserCount()
        {
            int count = _context.CompanyUsers.Count();
            return count;
        }

        public async Task<List<CompanyUser>> GetCompanyUsers()
        {
            return await _context.CompanyUsers
                      .Include(c => c.CompanyNavigation)
                      .ToListAsync();
        }

        public async Task<List<Industry>> GetIndustries()
        {
            return await _context.Industries.ToListAsync();
        }

        public async Task<Industry> GetIndustryById(Guid IndustryId)
        {
            var industry = await _context.Industries
                                   .Where(i => i.Id == IndustryId)
                                   .FirstOrDefaultAsync();

            return industry;
        }

        public async Task<List<JobCategory>> GetJobCategories()
        {
           return await _context.JobCategories.ToListAsync();
        }

        public async Task<JobCategory> GetJobCategoryById(Guid jobCategoryId)
        {
            var category = await _context.JobCategories
                                   .Where(c => c.Id ==jobCategoryId)
                                   .FirstOrDefaultAsync();

            return category;
        }

        public int GetJobPostCount()
        {
            int count = _context.JobPosts.Count();
            return count;
        }

        public async Task<JobPost> GetJobPostsById(Guid jobPostId)
        {
            var jobPost = await _context.JobPosts
                                        .Where(j => j.Id == jobPostId)
                                        .FirstOrDefaultAsync();

            return jobPost;
        }

        public async Task<List<JobPost>> GetJobPostsByName(string jobTitle)
        {
            var filteredJobPosts = await _context.JobPosts
                                                 .Where(jobpost => jobpost.JobTitle.Contains(jobTitle))
                                                 .ToListAsync();

            return filteredJobPosts;
        }

        public async Task<JobProviderCompany> GetJobProviderCompanyById(Guid jobProviderCompanyId)
        {
           var jobProviderCompany = await _context.JobProviderCompanies
                                                  .Where(jc => jc.Id == jobProviderCompanyId)
                                                  .FirstOrDefaultAsync();

            return jobProviderCompany;
        }

        public int GetJobProviderCompanyCount()
        {
            int count = _context.JobProviderCompanies.Count();
            return count;
        }

        public async Task<JobSeeker> GetJobSeekerById(Guid jobSeekerId)
        {
            var jobSeeker = await _context.JobSeekers
                                          .Where(j => j.Id==jobSeekerId)
                                          .FirstOrDefaultAsync ();

            return jobSeeker;
        }

        public int GetJobSeekerCount()
        {
            int count = _context.JobSeekers.Count();
            return count;
        }

        public async Task<List<JobSeeker>> GetJobSeekers()
        {
            return await _context.JobSeekers.ToListAsync();
        
        }

        public Task<Location> GetLocationById(Guid locationId)
        {
            var location = _context.Locations
                                    .Where(j => j.Id == locationId)
                                    .FirstOrDefaultAsync();

            return location;
        }

        public async Task<List<Location>> GetLocations()
        {
           return await _context.Locations.ToListAsync();
        }

        public async Task<List<Skill>> GetSkills()
        {
           return await _context.Skills.ToListAsync();
        }

        public Task<Skill> GetSkillsById(Guid skillId)
        {
            var skill = _context.Skills
                                .Where(sk =>  sk.Id==skillId)   
                                .FirstOrDefaultAsync();

            return skill;
        }

        public async Task<Industry> RemoveIndustryById(Guid industryId)
        {
            var item = await _context.Industries.FindAsync(industryId);

            if(item != null)
            {
                _context.Industries.Remove(item);
                await _context.SaveChangesAsync();
            }

            return item;
        }

        public async Task<JobCategory> RemoveJobCategoryById(Guid jobCategoryId)
        {
            var item = await _context.JobCategories.FindAsync(jobCategoryId);

            if (item != null)
            {
                _context.JobCategories.Remove(item);
                await _context.SaveChangesAsync();
            }

            return item;
        }

        public async Task<Location> RemoveLocationById(Guid locationId)
        {
            var item = await _context.Locations.FindAsync(locationId);

            if (item != null)
            {
                _context.Locations.Remove(item);
                await _context.SaveChangesAsync();
            }

            return item;
        }

        public async Task<Skill> RemoveSkillById(Guid skillId)
        {
            var item = await _context.Skills.FindAsync(skillId);

            if (item != null)
            {
                _context.Skills.Remove(item);
               await _context.SaveChangesAsync();
            }

            return item;
        }

        public async Task<List<JobProviderCompany>> SearchJobProviderCompanyByName(string name)
        {
            var filteredCompanies = await _context.JobProviderCompanies
                                                 .Where(companies => companies.LegalName.Contains(name))
                                                 .ToListAsync();

            return filteredCompanies;
        }

        public async Task<Industry> UpdateIndustry(Industry updatedIndustry, Guid industryId)
        {
            var industry = await _context.Industries.FindAsync(industryId);    

            if(industry != null)
            {
                industry.Name = updatedIndustry.Name;
                industry.Description = updatedIndustry.Description;

                _context.Industries.Update(industry);
                await _context.SaveChangesAsync();

                return industry;
            }

            return null;
        }

        public async Task<JobCategory> UpdateJobCategory(JobCategory updatedJobCategory, Guid jobCategoryId)
        {
            var category = await _context.JobCategories.FindAsync(jobCategoryId);

            if (category != null)
            {
                category.Name = updatedJobCategory.Name;
                category.Description = updatedJobCategory.Description;

                _context.JobCategories.Update(category);
                await _context.SaveChangesAsync();

                return category;
            }

            return null;
        }

        public async Task<Location> UpdateLocation(Location updatedLocation, Guid locationId)
        {
            var location = await _context.Locations.FindAsync(locationId);

            if (location != null)
            {
                location.Name = updatedLocation.Name ;
                location.Description = updatedLocation.Description;

                _context.Locations.Update(location);
                await _context.SaveChangesAsync();

                return location;
            }

            return null;
        }

        public async Task<Skill> UpdateSkill(Skill updatedSkill, Guid skillId)
        {
            var skill = await _context.Skills.FindAsync(skillId);

            if (skill != null)
            {
                skill.Name = updatedSkill.Name;
                skill.Description = updatedSkill.Description;

                _context.Skills.Update(skill);
                await _context.SaveChangesAsync();

                return skill;
            }

            return null;
        }
    }
}
