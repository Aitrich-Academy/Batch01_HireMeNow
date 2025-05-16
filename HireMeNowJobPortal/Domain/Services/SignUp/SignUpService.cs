using AutoMapper;
using Domain.Models;
using Domain.Services.AuthUser.Interfaces;
using Domain.Services.SignUp.DTO;
using Domain.Services.SignUp.Interfaces;
using NETCore.MailKit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.SignUp
{
    public class SignUpService : ISignUpRequestService
    {
        ISignUpRequestRepository jobSeekerRepository;
        IAuthUserRepository authUserRepository;
        IMapper mapper;
        IEmailService emailService;
        public SignUpService(ISignUpRequestRepository _jobSeekerRepository, IMapper _mapper, IEmailService _emailService, IAuthUserRepository _authUserRepository)
        {
            jobSeekerRepository = _jobSeekerRepository;
            mapper = _mapper;
            emailService = _emailService;
            authUserRepository = _authUserRepository;
        }
        public async Task CreateJobseeker(Guid jobSeekerSignupRequestId, string password)
        {
            try
            {
                SignUpRequest signUpRequest = await jobSeekerRepository.GetSignupRequestByIdAsync(jobSeekerSignupRequestId);
                
                Models.AuthUser authUser = new();
                if (signUpRequest.Status == Enums.Status.VERIFIED)
                {
                    authUser.UserName = signUpRequest.UserName;
                    authUser.Role = Enums.Role.JOB_SEEKER;
                    authUser.FirstName = signUpRequest.FirstName;
                    authUser.LastName = signUpRequest.LastName;
                    authUser.Email = signUpRequest.Email;
                    authUser.Password = password;
                    authUser.Phone = signUpRequest.Phone;
                    authUser = await authUserRepository.AddAuthUserJS(authUser);
                    signUpRequest.Status = Enums.Status.CREATED;
                    await jobSeekerRepository.UpdateSignupRequest(signUpRequest);
                }

                Models.JobSeeker jobseeker = mapper.Map<Models.JobSeeker>(authUser);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateSignupRequest(JobSeekerSignUpRequestDTO data)
        {
            var jobSeekerSignUpRequest = mapper.Map<SignUpRequest>(data);
            var signUpId = jobSeekerRepository.AddSignUpRequest(jobSeekerSignUpRequest);
        }

        public async Task<bool> VerifyEmailAsync(Guid jobSeekerSignupRequestId)
        {
            SignUpRequest signUpRequest = await jobSeekerRepository.GetSignupRequestByIdAsync(jobSeekerSignupRequestId);
            if (signUpRequest != null)
            {
                signUpRequest.Status = Enums.Status.VERIFIED;
                await jobSeekerRepository.UpdateSignupRequest(signUpRequest);
                return true;
            }
            return false;
        }
    }
}
