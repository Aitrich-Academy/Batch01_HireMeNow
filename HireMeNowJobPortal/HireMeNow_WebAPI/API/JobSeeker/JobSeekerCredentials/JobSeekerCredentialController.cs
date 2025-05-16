using AutoMapper;
using Domain.Models;
using Domain.Services.Login.Interfaces;
using Domain.Services.SignUp.DTO;
using Domain.Services.SignUp.Interfaces;
using HireMeNow_WebAPI.API.JobSeeker.Job;
using HireMeNow_WebAPI.API.JobSeeker.JobSeekerCredentials.Requests;
using HireMeNow_WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HireMeNow_WebAPI.API.JobSeeker.JobSeekerCredentials
{
    public class JobSeekerCredentialController : BaseApiController<JobSeekerCredentialController>
    {
        public ISignUpRequestService jobSeekerService { get; set; }

        public ILoginRequestService loginRequestService { get; set; }
        private readonly DbHireMeNowWebApiContext _context;
        public IMapper mapper { get; set; }
        public static AuthUser LoggedUser;
        public JobSeekerCredentialController(ISignUpRequestService _jobSeekerService, IMapper _mapper, ILoginRequestService _loginRequestService, DbHireMeNowWebApiContext context)
        {
            jobSeekerService = _jobSeekerService;
            loginRequestService = _loginRequestService;
            mapper = _mapper;
            _context = context;
        }
        [HttpPost]
        [Route("JobSeeker/Signup")]
        public async Task<ActionResult> createJobSeekerSignupRequest(JobSeekerSignUpRequest data)
        {
            var requestExists = _context.SignUpRequests.Any(a => a.Email == data.Email);
            if (requestExists)
            {
                throw new Exception("Signup request with this email already exists.");
            }
            var jobSeekerSignupRequestDto = mapper.Map<JobSeekerSignUpRequestDTO>(data);
            jobSeekerService.CreateSignupRequest(jobSeekerSignupRequestDto);
            return Ok(data);
        }

        [HttpGet]
        [Route("JobSeeker/Signup/{jobSeekerSignupRequestId}/verify-email")]
        public async Task<ActionResult> VerifyJobSeekerEmail(Guid jobSeekerSignupRequestId)
        {
            var isVerified = await jobSeekerService.VerifyEmailAsync(jobSeekerSignupRequestId);
            if (isVerified)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("JobSeeker/Signup/{jobSeekerSignupRequestId}/set-password")]
        public async Task<ActionResult> createJobSeekerSignupRequest(Guid jobSeekerSignupRequestId, [FromBody] string password)
        {
            await jobSeekerService.CreateJobseeker(jobSeekerSignupRequestId, password);
            return Ok("Password Set Successfully");
        }

        [HttpPost]
        [Route("JobSeeker/Login")]
        public async Task<ActionResult> Login(JobSeekerLoginRequest logData)
        {
           
            var user = loginRequestService.login(logData.Email, logData.Password);

            if (user == null)
            {
                return BadRequest("Login Failed");
            }
           
            return Ok(user);
        }
    }
}
