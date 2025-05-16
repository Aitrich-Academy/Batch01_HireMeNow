using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.SignUp.Interfaces
{
    public interface ISignUpRequestRepository
    {
        Task AddJobSeekerAsync(Models.JobSeeker jobseeker);
        Task<Guid> AddSignUpRequest(SignUpRequest signUpRequest);
        Task<SignUpRequest> GetSignupRequestByIdAsync(Guid jobSeekerSignupRequestId);
        Task UpdateSignupRequest(SignUpRequest signUpRequest);
    }
}
