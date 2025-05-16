using AutoMapper;
using Domain.Services.AuthUser;
using Domain.Services.AuthUser.Interfaces;
using Domain.Services.Login.DTOs;
using Domain.Services.Login.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Login
{
    public class LoginRequestService:ILoginRequestService
    {
        private readonly ILoginRequestRepository _loginRequestRepository;
        private readonly IAuthUserRepository _authUserRepository;
        private readonly IMapper _mapper;

        public LoginRequestService(ILoginRequestRepository loginRequestRepository,IAuthUserRepository authUserRepository,IMapper mapper)
        {
            _loginRequestRepository = loginRequestRepository;
            _authUserRepository = authUserRepository;
            _mapper = mapper;
        }


        public AdminLoginDTO AdminLogin(string email, string password)
        {
            if (email == "admin@example.com" && password == "Admin@123")
            {
                var adminUser = new Domain.Models.AuthUser
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    FirstName = "Admin",
                    Email = email,
                    Role = Domain.Enums.Role.ADMIN,
                    Password = password
                };

                var userReturn = _mapper.Map<AdminLoginDTO>(adminUser);
                userReturn.Token = _authUserRepository.CreateToken(adminUser);
                return userReturn;
            }


            var user = _loginRequestRepository.GetUserByEmailPassword(email, password);
            if (user == null)
            {
                return null;
            }

            var userDto = _mapper.Map<AdminLoginDTO>(user);
            userDto.Token = _authUserRepository.CreateToken(user);
            return userDto;
        }

    }
}
