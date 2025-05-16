using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobSeeker.Job.Interfaces
{
    public interface IJobService
    {
        Task<List<JobPost>> GetAllJobPosts(Guid userId);
        Task<JobPost> GetJobPostById(Guid id);
        Task ApplyJob(JobApplication application);
        Task<List<JobApplication>> GetAllJobApplications(Guid applicantId);
        Task<JobApplication> GetJobApplicationById(Guid applicationId);
        Task<int> GetJobApplicationCount(Guid applicantId);
        Task SaveJob(SavedJob savedJob);
        Task<List<SavedJob>> GetAllSavedJobs(Guid jobSeekerId);
        Task<SavedJob> GetSavedJobById(Guid savedJobId);
        Task DeleteSavedJobs(Guid savedJobId);
        Task<List<JobPost>> SearchJobByKeyword(string keyword);
        Task<List<Interview>> GetScheduledInterviews(Guid intervieweeId);
        Task<Interview> GetInterViewById(Guid InterviewId);
        Task UpdateInterviewStatus(Guid InterviewId, JobInterviewStatus status);
    }
}
