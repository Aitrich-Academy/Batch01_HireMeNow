﻿using Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.AuthUser.Interfaces
{
    public interface IAuthUserService
    {
        string GetUserId();
        Guid GetUserProfileId();
        CompanyUser GetUser(Guid userid);
    }
}



