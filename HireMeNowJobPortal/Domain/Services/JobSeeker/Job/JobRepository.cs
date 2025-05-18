using Domain.Enums;
using Domain.Exceptions;
using Domain.Models;
using Domain.Services.JobSeeker.Job.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services.JobSeeker.Job
{
    public class JobRepository : IJobRepository
    {
        private readonly DbHireMeNowWebApiContext _dbContext;
        public JobRepository(DbHireMeNowWebApiContext context)
        {
            _dbContext = context;

        }
        public async Task ApplyJob(JobApplication application)
        {
            _dbContext.JobApplications.Add(application);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteSavedJobs(Guid savedJobId)
        {
            var deleteJob = _dbContext.SavedJobs.Find(savedJobId);
            if (deleteJob != null)
            {
                _dbContext.SavedJobs.Remove(deleteJob);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ItemNotFoundException("Job not found");
            }
        }

        public async Task<List<JobApplication>> GetAllJobApplications(Guid applicantId)
        {
            return _dbContext.JobApplications.Where(a => a.Applicant == applicantId)
                .Include(a => a.JobPost)
                .Include(a => a.Resume)
                .Include(a => a.Seeker)
                .Include(a => a.Interviews)
                .ToList();
        }

        public async Task<List<JobPost>> GetAllJobPosts(Guid userId)
        {
            return await _dbContext.JobPosts
                .Include(a => a.Location)
                .Include(a => a.PostedByNavigation)
                .Include(a => a.JobCategory)
                .Include(a => a.Industry)
                .Include(a => a.Company)
                //.Select(a => new  JobPostDTO
                //{
                //    JobTitle = a.JobTitle,
                //    JobSummary = a.JobSummary,
                //    Location = a.Location != null ? a.Location.Name: null,
                //    CompanyName = a.Company != null ? a.Company.LegalName : null,
                //    CategoryName = a.JobCategory != null ? a.JobCategory.Name : null,
                //    IndustryName = a.Industry != null ? a.Industry.Name : null,
                //    PostedDate = a.PostedDate
                //})
        .ToListAsync();
        }

        public async  Task<List<SavedJob>> GetAllSavedJobs(Guid jobSeekerId)
        {
            return await _dbContext.SavedJobs.Where(a => a.SavedBy == jobSeekerId)
                .Include(a => a.JobPost)
                .Include(a => a.JobSeekerNavigation)
                .ToListAsync();
        }

        

        public async Task<JobApplication> GetJobApplicationById(Guid applicationId)
        {
            var job =await _dbContext.JobApplications
                .Include(a => a.JobPost)
                .Include(a => a.Resume)
                .Include(a => a.Seeker)
                .Include(a => a.Interviews)
                .FirstOrDefaultAsync(a => a.Id == applicationId);
            if (job != null)
            {
                return job;
            }
            else
            {
                throw new ItemNotFoundException("Job not found");
            }
        }

        public async Task<int> GetJobApplicationCount(Guid applicantId)
        {
            int appliedCount =await _dbContext.JobApplications.Where(c=>c.Applicant==applicantId).CountAsync();
            return appliedCount;
        }

        public async Task<JobPost> GetJobPostById(Guid id)
        {
            var job =await _dbContext.JobPosts
                .Include(a => a.Location)
                .Include(a => a.PostedByNavigation)
                .Include(a => a.JobCategory)
                .Include(a => a.Industry)
                .Include(a => a.Company)

                .FirstOrDefaultAsync(a => a.Id == id);
            if (job != null)
            {
                return job;
            }
            else
            {
                throw new ItemNotFoundException("Job not found");
            }
        }

        public async Task<SavedJob> GetSavedJobById(Guid savedJobId)
        {
            var job =await _dbContext.SavedJobs
                .Include(a => a.JobPost)
                .Include(a => a.JobSeekerNavigation)
                .FirstOrDefaultAsync(a => a.Id == savedJobId);

            if (job != null)
            {
                return job;
            }
            else
            {
                throw new ItemNotFoundException("Job not found");
            }
        }

        
        public async Task SaveJob(SavedJob savedJob)
        {
            _dbContext.SavedJobs.Add(savedJob);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<JobPost>> SearchJobByKeyword(string keyword)
        {
            var jobs =await _dbContext.JobPosts
                     .Include(a => a.Location)
                     .Include(a => a.PostedByNavigation)
                     .Include(a => a.JobCategory)
                     .Include(a => a.Industry)
                     .Include(a => a.Company)
                     .Where(a => a.JobTitle.Contains(keyword) || a.Company.LegalName.Contains(keyword))
                     .ToListAsync();
            return jobs;
        }
        public async Task<Interview> GetInterViewById(Guid InterviewId)
        {
            var interview = await _dbContext.Interviews.FirstOrDefaultAsync(a => a.Id == InterviewId);
            if (interview == null)
                throw new Exception("Interview not found.");
            return interview;
        }
        public async Task<List<Interview>> GetScheduledInterviews(Guid intervieweeId)
        {
            return await _dbContext.Interviews.Where(i=>i.Interviewee==intervieweeId).ToListAsync();
        }

        public async Task UpdateInterviewStatus(Guid InterviewId, JobInterviewStatus status)
        {
            var interview = await _dbContext.Interviews.FirstOrDefaultAsync(a => a.Id == InterviewId);
            if (interview == null)
                throw new Exception("Interview not found.");
            interview.Status = status;
            await _dbContext.SaveChangesAsync();
        }
    }
}

