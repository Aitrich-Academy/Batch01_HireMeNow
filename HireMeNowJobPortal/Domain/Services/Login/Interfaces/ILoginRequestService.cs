
using Domain.Services.Login.DTO;
using Domain.Services.Login.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Login.Interfaces
{
    public interface ILoginRequestService
    {
        AdminLoginDTO AdminLogin(string email, string password);
        LoginDTO login(string email, string password);
        Guid LoggedUserId();
    }
        
}
