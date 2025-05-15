using Domain.Models;
using Domain.Services.Login.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Login
{
    public class LoginRequestRepository : ILoginRequestRepository
    {
        private readonly DbHireMeNowWebApiContext _context;
        public LoginRequestRepository(DbHireMeNowWebApiContext context)
        {
            _context = context;
        }
        Models.AuthUser ILoginRequestRepository.GetUserByEmailPassword(string email, string password)
        {
            var user = _context.AuthUsers
                              .FirstOrDefault(e => e.Email == email && e.Password == password);

            return user;
        }
    }
}
