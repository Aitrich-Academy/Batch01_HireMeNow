using AutoMapper;
using Domain.Models;
using Domain.Services.AuthUser.Interfaces;
using Domain.Services.JobSeeker.Job.DTO;
using Domain.Services.JobSeeker.Job.Interfaces;
using Domain.Services.Login;
using Domain.Services.Login.Interfaces;
using HireMeNow_WebAPI.API.JobSeeker.Job.DTO;
using HireMeNow_WebAPI.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNow_WebAPI.API.JobSeeker.Job
{
    [ApiController]
    [Authorize(Roles = "JOB_SEEKER")]
    public class JobController : BaseApiController<JobController>
    {
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;
        private readonly IAuthUserService _userService;
        
        public JobController(IJobService jobService, IMapper mapper, IAuthUserService userService)
        {
            _jobService = jobService;
            _mapper = mapper;
            _userService = userService;
           
        }

        [HttpGet("JobPostList")]
        public async Task<IActionResult> GetAllJobPost()
        {
            try
            {
                var userId = new Guid(_userService.GetUserId());
                var jobEntity = await _jobService.GetAllJobPosts(userId); 
                var jobList = _mapper.Map<List<JobPostDTO>>(jobEntity);
                return Ok(jobList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Job/{jobId:guid}")]
        public async Task<IActionResult> GetJobPostById(Guid jobId)
        {
            try
            {
                var jobEntity = await _jobService.GetJobPostById(jobId); 

                if (jobEntity == null)
                    return NotFound("Job post not found.");

                var job = _mapper.Map<JobPostDTO>(jobEntity);
                return Ok(job);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchJob([FromQuery] string keyword)
        {
            try
            {
                if (string.IsNullOrEmpty(keyword))
                {
                    return BadRequest("Keyword required");
                }

                var jobEntity = await _jobService.SearchJobByKeyword(keyword); 
                var jobList = _mapper.Map<List<JobPostDTO>>(jobEntity);
                return Ok(jobList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("ApplyJob")]
        public async Task<IActionResult> ApplyForJob(JobApplicationDTO jobApplicationDTO)
        {
            try
            {
                Guid applicantId = new Guid(_userService.GetUserId());
                var newApplication = new JobApplication
                {
                    JobPost_id=jobApplicationDTO.JobPostId,
                    Applicant=applicantId,
                    Resume_id=jobApplicationDTO.ResumeId,
                    CoverLetter=jobApplicationDTO.CoverLetter,
                    DateSubmitted=DateTime.Now
                    
                };
                await _jobService.ApplyJob(newApplication);
                return Ok($"Job applied on {newApplication.DateSubmitted}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("AppliedJobList")]
        public async Task<IActionResult> AppliedJobList()
        {
            Guid applicantId = new Guid(_userService.GetUserId());
            var appliedList=await _jobService.GetAllJobApplications(applicantId);
            var applicationJobList=_mapper.Map<List<JobApplicationDTO>>(appliedList);
            return Ok(applicationJobList);
        }

        [HttpGet("AppliedJob{appliedJobId:guid}")]
        public async Task<IActionResult> AppliedJobById(Guid appliedJobId)
        {
            var appliedJob=await _jobService.GetJobApplicationById(appliedJobId);
            var applicationJobList = _mapper.Map<JobApplicationDTO>(appliedJob);
            return Ok(applicationJobList);
        }

        [HttpGet("AppliedCount")]
        public async Task<IActionResult> AppliedCount()
        {
            Guid applicantId = new Guid(_userService.GetUserId());
            int count=await _jobService.GetJobApplicationCount(applicantId);
            return Ok(count);
        }

        [HttpPost("SaveJob")]
        public async Task<IActionResult> SaveJobs(SavedJobDTO savedJobDTO)
        {
            Guid userId= new Guid(_userService.GetUserId());
            var newSavedJob = new SavedJob
            {
                Job=savedJobDTO.Job,
                SavedBy=userId,
                DateSaved=DateTime.Now,

            };
            await _jobService.SaveJob(newSavedJob);
            return Ok($"Job saved on {newSavedJob.DateSaved}");
        }

        [HttpGet("SavedJobList")]
        public async Task<IActionResult> GetSavedJobList()
        {
            Guid userId = new Guid(_userService.GetUserId());
            var savedList = await _jobService.GetAllSavedJobs(userId);
            var savedJobList=_mapper.Map<List<SavedJobDTO>>(savedList);
            return Ok(savedJobList);
        }

        [HttpGet("SavedJob{savedJobId:guid}")]
        public async Task<IActionResult> GetSavedJobById(Guid savedJobId)
        {
            var savedJob=await _jobService.GetSavedJobById(savedJobId);
            var savedJobList = _mapper.Map<SavedJobDTO>(savedJob);
            return Ok(savedJobList);
        }

        [HttpGet("RemoveSavedJob{savedJobId:guid}")]
        public async Task<IActionResult> DeleteSavedJob(Guid savedJobId)
        {
            await _jobService.DeleteSavedJobs(savedJobId);
            return Ok("Saved job deleted successfully");
        }

        [HttpGet("ScheduledInterviewList")]
        public async Task<IActionResult> InterviewList()
        {
            Guid userId = new Guid(_userService.GetUserId());
            var interviews= await _jobService.GetScheduledInterviews(userId);
            var interviewScheduledList = _mapper.Map<List<InterviewDTO>>(interviews);
            return Ok(interviewScheduledList);
        }

        [HttpGet("GetInterView{interviewId:guid}")]
        public async Task<IActionResult> GetInterviewById(Guid interviewId)
        {
            var interview=await _jobService.GetInterViewById(interviewId);
            var interviewScheduledList = _mapper.Map<InterviewDTO>(interview);
            return Ok(interviewScheduledList);
        }

        [HttpPost("UpdateInterviewStatus")]
        public async Task<IActionResult> UpdateInterviewStatus(InterviewUpdateDTO interviewUpdate)
        {
            await _jobService.UpdateInterviewStatus(interviewUpdate.InterviewId, interviewUpdate.Status);
            return Ok("Interview status updated successfully");
        }
    }
}
