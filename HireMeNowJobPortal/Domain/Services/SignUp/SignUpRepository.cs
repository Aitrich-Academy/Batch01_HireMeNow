using Domain.Enums;
using Domain.Models;
using Domain.Services.SignUp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.SignUp
{
    public class SignUpRepository : ISignUpRequestRepository
    {
        protected readonly DbHireMeNowWebApiContext _context;
        public SignUpRepository(DbHireMeNowWebApiContext dbContext)
        {
            _context = dbContext;
        }
        public async Task AddJobSeekerAsync(Models.JobSeeker jobseeker)
        {
            await _context.JobSeekers.AddAsync(jobseeker);  
            _context.SaveChanges();
        }

        public async Task<Guid> AddSignUpRequest(SignUpRequest signUpRequest)
        {
            
            signUpRequest.Status = Status.PENDING;
            await _context.SignUpRequests.AddAsync(signUpRequest);
            _context.SaveChanges();
            return signUpRequest.Id;
        }

        public async Task<SignUpRequest> GetSignupRequestByIdAsync(Guid jobSeekerSignupRequestId)
        {
            return await _context.SignUpRequests.FindAsync(jobSeekerSignupRequestId);
        }

        public async Task UpdateSignupRequest(SignUpRequest signUpRequest)
        {
            _context.SignUpRequests.Update(signUpRequest);
            await _context.SaveChangesAsync();
        }
    }
}
