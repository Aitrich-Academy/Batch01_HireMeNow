using Domain.Services.SignUp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.SignUp.Interfaces
{
    public interface ISignUpRequestService
    {
        Task CreateJobseeker(Guid jobSeekerSignupRequestId, string password);

        
        void CreateSignupRequest(JobSeekerSignUpRequestDTO data);

        Task<bool> VerifyEmailAsync(Guid jobSeekerSignupRequestId);
    }
}
