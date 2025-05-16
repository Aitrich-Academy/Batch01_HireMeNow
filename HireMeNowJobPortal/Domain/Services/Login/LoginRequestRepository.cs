using Domain.Models;
using Domain.Services.Login.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Login
{
    public class LoginRequestRepository : ILoginRequestRepository
    {
        private readonly DbHireMeNowWebApiContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoginRequestRepository(DbHireMeNowWebApiContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        Models.AuthUser ILoginRequestRepository.GetUserByEmailPassword(string email, string password)
        {
            var user = _context.AuthUsers
                              .FirstOrDefault(e => e.Email == email && e.Password == password);

            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
        public Guid LoggedUserId()
        {
            var email = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;

            if (string.IsNullOrEmpty(email))
                throw new Exception("Email claim not found in token.");

            var user = _context.JobSeekers.FirstOrDefault(a => a.Email == email);

            if (user == null)
                throw new Exception("User not found with the provided email.");

            return user.Id;
        }
    }
}
