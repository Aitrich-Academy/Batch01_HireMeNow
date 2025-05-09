using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Services.AuthUser.Interfaces
{
    public interface IAuthUserRepository
    {
       Task<Domain.Models.AuthUser> AddAuthUserJS(Domain.Models.AuthUser authUser);
       Task<Domain.Models.AuthUser> AddAuthUserJP(Domain.Models.AuthUser authUser);
       string? CreateToken(Domain.Models.AuthUser user);
    }
}


