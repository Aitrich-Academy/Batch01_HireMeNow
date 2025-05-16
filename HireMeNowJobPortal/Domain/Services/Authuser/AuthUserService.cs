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
        public AuthUserService(IHttpContextAccessor httpContextAccessor, IAuthUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
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
    }
}
