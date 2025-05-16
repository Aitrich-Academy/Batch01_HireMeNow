using Domain.Models;
using Domain.Services.JobSeeker.JobSeekerProfile.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobSeeker.JobSeekerProfile
{
    public class JobSeekerProfileService : IJobSeekerService
    {
        private readonly IJobSeekerProfileRepository _jobSeekerProfileRepository;
        public JobSeekerProfileService(IJobSeekerProfileRepository jobSeekerProfileRepository)
        {
            _jobSeekerProfileRepository = jobSeekerProfileRepository;
        }

        public async Task AddJobSeekerQualification(Qualification qualification)
        {
            await _jobSeekerProfileRepository.AddJobSeekerQualification(qualification);
        }

        public async Task AddJobSeekerSkills(JobSeekerProfileSkill skills)
        {
            await _jobSeekerProfileRepository.AddJobSeekerSkills(skills);
        }

        public async Task AddResume(Resume resume)
        {
            await _jobSeekerProfileRepository.AddResume(resume);
        }

        public async Task AddWorkExperience(WorkExperience workExperience)
        {
            await _jobSeekerProfileRepository.AddWorkExperience(workExperience);
        }

        public async Task CreateJobSeekerProfile(Models.JobSeekerProfile jobSeekerProfile)
        {
            await _jobSeekerProfileRepository.CreateJobSeekerProfile(jobSeekerProfile);
        }

        public async Task DeleteJobSeekerProfile(Guid jobSeekerProfileId)
        {
            await _jobSeekerProfileRepository.DeleteJobSeekerProfile(jobSeekerProfileId);
        }

        public async Task DeleteJobSeekerQualification(Guid jobSeekerProfileId, Guid jobSeekerQualificationId)
        {
            await _jobSeekerProfileRepository.DeleteJobSeekerQualification(jobSeekerProfileId, jobSeekerQualificationId);
        }

        public async Task DeleteJobSeekerSkills(Guid jobSeekerProfileId, Guid skillId)
        {
            await _jobSeekerProfileRepository.DeleteJobSeekerSkills(jobSeekerProfileId, skillId);
        }

        public async Task DeleteResume(Guid resumeId)
        {
            await _jobSeekerProfileRepository.DeleteResume(resumeId);
        }

        public async Task DeleteWorkExperience(Guid profileId, Guid WorkExperienceId)
        {
            await _jobSeekerProfileRepository.DeleteWorkExperience(profileId, WorkExperienceId);
        }

        public async Task<List<Qualification>> GetAllQualifications(Guid profileId)
        {
           return await _jobSeekerProfileRepository.GetAllQualifications(profileId);
        }

        public async Task<List<WorkExperience>> GetAllWorkExperience(Guid profileId)
        {
            return await _jobSeekerProfileRepository.GetAllWorkExperience(profileId);
        }

        public async Task<Models.JobSeekerProfile> GetJobSeekerProfile(Guid jobSeekerProfileId)
        {
            return await _jobSeekerProfileRepository.GetJobSeekerProfile(jobSeekerProfileId);
        }

        public async Task<List<JobSeekerProfileSkill>> GetJobSeekerSkills(Guid jobSeekerProfileId)
        {
            return await _jobSeekerProfileRepository.GetJobSeekerSkills(jobSeekerProfileId);
        }

        public async Task<Resume> GetResumeById(Guid profileId)
        {
            return await _jobSeekerProfileRepository.GetResumeById(profileId);
        }

        public async Task<List<Resume>> GetResumes(Guid seekerId)
        {
            return await _jobSeekerProfileRepository.GetResumes(seekerId);
        }

        public async Task UpdateJobSeekerProfile(Models.JobSeekerProfile jobSeekerProfile)
        {
            await _jobSeekerProfileRepository.UpdateJobSeekerProfile(jobSeekerProfile);
        }

        public async Task UpdateJobSeekerQualification(Qualification jobSeekerQualification)
        {
            await _jobSeekerProfileRepository.UpdateJobSeekerQualification(jobSeekerQualification);
        }

        public async Task UpdateResume(Resume resume)
        {
            await _jobSeekerProfileRepository.UpdateResume(resume);
        }

        public async Task UpdateWorkExperience(WorkExperience workExperience)
        {
            await _jobSeekerProfileRepository.UpdateWorkExperience(workExperience);
        }
    }
}
