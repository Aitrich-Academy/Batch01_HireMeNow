using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobSeeker.JobSeekerProfile.Interfaces
{
    public interface IJobSeekerService
    {
        Task CreateJobSeekerProfile(Models.JobSeekerProfile jobSeekerProfile);
        Task<Models.JobSeekerProfile> GetJobSeekerProfile(Guid jobSeekerProfileId);
        Task UpdateJobSeekerProfile(Models.JobSeekerProfile jobSeekerProfile);
        Task DeleteJobSeekerProfile(Guid jobSeekerProfileId);
        Task AddJobSeekerSkills(JobSeekerProfileSkill skills);
        
        Task DeleteJobSeekerSkills(Guid jobSeekerProfileId, Guid skillId);
        Task<List<JobSeekerProfileSkill>> GetJobSeekerSkills(Guid jobSeekerProfileId);
        Task AddResume(Resume resume);
        Task UpdateResume(Resume resume);
        Task DeleteResume(Guid resumeId);
        Task<List<Resume>> GetResumes(Guid profileId);
        Task<Resume> GetResumeById(Guid profileId);
        Task AddWorkExperience(WorkExperience workExperience);
        Task UpdateWorkExperience(WorkExperience workExperience);
        Task DeleteWorkExperience(Guid profileId, Guid WorkExperienceId);
        Task<List<WorkExperience>> GetAllWorkExperience(Guid profileId);
        Task AddJobSeekerQualification(Qualification qualification);
        Task UpdateJobSeekerQualification(Qualification jobSeekerQualification);
        Task DeleteJobSeekerQualification(Guid jobSeekerProfileId, Guid jobSeekerQualificationId);
        Task<List<Qualification>> GetAllQualifications(Guid profileId);
    }
}
