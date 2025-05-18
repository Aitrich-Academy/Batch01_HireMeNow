using Domain.Enums;
using Domain.Models;
using Domain.Services.JobSeeker.Job.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobSeeker.Job
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;
        public JobService(IJobRepository jobRepository)
        {
           _jobRepository = jobRepository;

        }
        public async Task ApplyJob(JobApplication application)
        {
           await _jobRepository.ApplyJob(application);
        }

        public async Task DeleteSavedJobs(Guid savedJobId)
        {
            await _jobRepository.DeleteSavedJobs(savedJobId);
        }

        public async Task<List<JobApplication>> GetAllJobApplications(Guid applicantId)
        {
            return await _jobRepository.GetAllJobApplications(applicantId);
        }

        public async Task<List<JobPost>> GetAllJobPosts(Guid userId)
        {
            return await _jobRepository.GetAllJobPosts(userId);
        }

        public async Task<List<SavedJob>> GetAllSavedJobs(Guid jobSeekerId)
        {
            return await _jobRepository.GetAllSavedJobs(jobSeekerId);
        }


        public async Task<JobApplication> GetJobApplicationById(Guid applicationId)
        {
            return await _jobRepository.GetJobApplicationById(applicationId);
        }

        public async Task<int> GetJobApplicationCount(Guid applicantId)
        {
            return await _jobRepository.GetJobApplicationCount(applicantId);
        }

        public async Task<JobPost> GetJobPostById(Guid id)
        {
            return await _jobRepository.GetJobPostById(id);
        }

        public async Task<SavedJob> GetSavedJobById(Guid savedJobId)
        {
            return await _jobRepository.GetSavedJobById(savedJobId);
        }

       

        public async Task SaveJob(SavedJob savedJob)
        {
            await _jobRepository.SaveJob(savedJob);
        }

        public async Task<List<JobPost>> SearchJobByKeyword(string keyword)
        {
            return await _jobRepository.SearchJobByKeyword(keyword);
        }

        public async Task UpdateInterviewStatus(Guid InterviewId, JobInterviewStatus status)
        {
            await _jobRepository.UpdateInterviewStatus(InterviewId, status);
        }

        public async Task<Interview> GetInterViewById(Guid InterviewId)
        {
            return await _jobRepository.GetInterViewById(InterviewId);
        }
        public async Task<List<Interview>> GetScheduledInterviews(Guid intervieweeId)
        {
            return await _jobRepository.GetScheduledInterviews(intervieweeId);
        }
    }
}

