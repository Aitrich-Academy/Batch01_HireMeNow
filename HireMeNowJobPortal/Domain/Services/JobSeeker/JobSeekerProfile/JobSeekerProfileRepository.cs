using Domain.Exceptions;
using Domain.Models;
using Domain.Services.JobSeeker.JobSeekerProfile.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobSeeker.JobSeekerProfile
{
    public class JobSeekerProfileRepository : IJobSeekerProfileRepository
    {
        private readonly DbHireMeNowWebApiContext _context;
        public JobSeekerProfileRepository(DbHireMeNowWebApiContext context)
        {
            _context = context;
        }
        public async Task AddJobSeekerQualification(Qualification qualification)
        {
            await _context.Qualifications.AddAsync(qualification);
            await _context.SaveChangesAsync();
        }

        public async Task AddJobSeekerSkills(JobSeekerProfileSkill skills)
        {
            await _context.JobSeekerProfileSkills.AddAsync(skills);
            await _context.SaveChangesAsync();
        }

        public async Task AddResume(Resume resume)
        {
           await _context.Resumes.AddAsync(resume);
            await _context.SaveChangesAsync();  
        }

        public async Task AddWorkExperience(WorkExperience workExperience)
        {
            await _context.WorkExperiences.AddAsync(workExperience);
            await _context.SaveChangesAsync();
        }

        public async Task CreateJobSeekerProfile(Models.JobSeekerProfile jobSeekerProfile)
        {
            await _context.JobSeekerProfiles.AddAsync(jobSeekerProfile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteJobSeekerProfile(Guid jobSeekerProfileId)
        {
            var jobSeekerProfile = await _context.JobSeekerProfiles.FindAsync(jobSeekerProfileId);
            if (jobSeekerProfile != null)
            {
                _context.JobSeekerProfiles.Remove(jobSeekerProfile);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteJobSeekerQualification(Guid jobSeekerProfileId, Guid jobSeekerQualificationId)
        {
            var qualification = await _context.Qualifications
            .FirstOrDefaultAsync(q => q.Id == jobSeekerQualificationId && q.JobseekerProfileId == jobSeekerProfileId);

            if (qualification != null)
            {
                _context.Qualifications.Remove(qualification);
                await _context.SaveChangesAsync();
            }


        }

        public async Task DeleteJobSeekerSkills(Guid jobSeekerProfileId, Guid skillId)
        {
            var deleteSkill = await _context.JobSeekerProfileSkills
                            .FirstOrDefaultAsync(s => s.SkillId == skillId && s.JobSeekerProfileId == jobSeekerProfileId);
            if(deleteSkill != null)
            {
                _context.JobSeekerProfileSkills.Remove(deleteSkill);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteResume(Guid resumeId)
        {
            var resume = await _context.Resumes.FindAsync(resumeId);
            if(resume != null)
            {
                _context.Resumes.Remove(resume);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteWorkExperience(Guid profileId, Guid WorkExperienceId)
        {
            var deleteExperience = await _context.WorkExperiences
                           .FirstOrDefaultAsync(s => s.Id == WorkExperienceId && s.JobSeekerProfileId == profileId);
            if (deleteExperience != null)
            {
                _context.WorkExperiences.Remove(deleteExperience);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Qualification>> GetAllQualifications(Guid profileId)
        {
            var qualifications = await _context.Qualifications
                                .Where(q => q.JobseekerProfileId == profileId)
                                
                                .ToListAsync();

            return qualifications;
        }

        public async Task<List<WorkExperience>> GetAllWorkExperience(Guid profileId)
        {
            var workExperiences=await _context.WorkExperiences
                                    .Where(e=>e.JobSeekerProfileId==profileId)
                                    .ToListAsync();
            return workExperiences;
        }

        public async Task<Models.JobSeekerProfile> GetJobSeekerProfile(Guid jobSeekerProfileId)
        {
            var profile=await _context.JobSeekerProfiles
                .Include(s=>s.JobSeekerProfileSkills)
                .Include(s=>s.Resume)
                .Include(s=>s.WorkExperiences)
                .Include(s=>s.Qualifications)
                .FirstOrDefaultAsync(s => s.Id == jobSeekerProfileId);
            if (profile == null)
            {
                throw new ItemNotFoundException("Profile not found");
            }
            return profile;
        }

        public async Task<List<JobSeekerProfileSkill>> GetJobSeekerSkills(Guid jobSeekerProfileId)
        {
            var profileSkills = await _context.JobSeekerProfileSkills
                              .Where(s => s.JobSeekerProfileId == jobSeekerProfileId)
                              .Include(s=>s.Skill)
                              .ToListAsync();
            return profileSkills;
        }

        public async Task<Resume> GetResumeById(Guid profileId)
        {
            var profile = await _context.JobSeekerProfiles.FindAsync(profileId);
            if (profile == null)
            {
                throw new ItemNotFoundException("Profile not found");
            }
            var resumeId = profile.ResumeId;
            var resumeToGet= await _context.Resumes.FindAsync(resumeId);
            if (resumeToGet == null)
            {
                throw new ItemNotFoundException("Resume not found");
            }
            return resumeToGet;
        }

        public async Task<List<Resume>> GetResumes(Guid seekerId)
        {
           var resumes=await _context.Resumes.Where(r=>r.JobSeekerId== seekerId).ToListAsync();
            return resumes;
        }

        public async Task UpdateJobSeekerProfile(Models.JobSeekerProfile jobSeekerProfile)
        {
            var existingProfile = await _context.JobSeekerProfiles.FirstOrDefaultAsync(j => j.Id == jobSeekerProfile.Id);
            if (existingProfile == null)
            {
                throw new ItemNotFoundException("Profile not found");
            }
            existingProfile.ResumeId = jobSeekerProfile.ResumeId != null ? jobSeekerProfile.ResumeId : existingProfile.ResumeId;
            existingProfile.ProfileName = jobSeekerProfile.ProfileName!=null?jobSeekerProfile.ProfileName:existingProfile.ProfileName;
            existingProfile.ProfileSummary=jobSeekerProfile.ProfileSummary!=null?jobSeekerProfile.ProfileSummary:existingProfile.ProfileSummary;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateJobSeekerQualification(Qualification jobSeekerQualification)
        {
            _context.Qualifications.Update(jobSeekerQualification);
            await _context.SaveChangesAsync();

            //var existingQualification = await _context.Qualifications
            //    .FirstOrDefaultAsync(q => q.Id == jobSeekerQualification.Id
            //        && q.JobseekerProfileId == jobSeekerQualification.JobseekerProfileId);

            //if (existingQualification == null)
            //{
            //    throw new ItemNotFoundException("Qualification not found for the specified job seeker.");
            //}

            // Optionally update fields manually
            //existingQualification.Name = jobSeekerQualification.Name!=null?jobSeekerQualification.Name : existingQualification.Name;
            //existingQualification.Description = jobSeekerQualification.Description!=null?jobSeekerQualification.Description: existingQualification.Description;

            // Add other fields as needed

        }

        

        public async Task UpdateResume(Resume resume)
        {
            _context.Resumes.Update(resume);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateWorkExperience(WorkExperience workExperience)
        {
            _context.WorkExperiences.Update(workExperience);
            await _context.SaveChangesAsync();
        }
    }
}
