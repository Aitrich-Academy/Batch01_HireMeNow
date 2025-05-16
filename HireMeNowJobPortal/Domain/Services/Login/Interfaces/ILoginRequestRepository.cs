using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Services.Login.Interfaces
{
    public interface ILoginRequestRepository
    {
        Domain.Models.AuthUser GetUserByEmailPassword(string email, string password);
        Guid LoggedUserId();
    }
}
