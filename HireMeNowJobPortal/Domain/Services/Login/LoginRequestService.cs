using AutoMapper;
using Domain.Services.AuthUser;
using Domain.Services.AuthUser.Interfaces;
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

        
    }
}
