using Domain.Models;
using Domain.Services.AuthUser.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.AuthUser
{
    public class AuthUserService : IAuthUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthUserRepository _userRepository;
        private readonly DbHireMeNowWebApiContext _context;
        public AuthUserService(IHttpContextAccessor httpContextAccessor, IAuthUserRepository userRepository, DbHireMeNowWebApiContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _context = context;
        }
        public string GetUserId()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Sid).Value.ToString();
            }
            return result;
        }

        public Guid GetUserProfileId()
        {
            var seekerId = new Guid(GetUserId());
            var profile = _context.JobSeekerProfiles.FirstOrDefault(j => j.JobSeekerId == seekerId);
            Guid profileId = profile.Id;
            return profileId;
        }

        public CompanyUser GetUser(Guid userid)
        {
            return _userRepository.GetUser(userid);
        }
    }
}
