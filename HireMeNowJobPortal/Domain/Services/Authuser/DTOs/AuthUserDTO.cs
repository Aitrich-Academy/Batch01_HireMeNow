using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Authuser.DTOs
{
    public class AuthUserDTO
    {
        Guid Id { get; set; }
        string? UserName { get; set; }
        string? FirstName { get; set; }
        string? LastName { get; set; }
        IFormFile? Image { get; set; }
        string? Phone { get; set; }
        string? Password { get; set; }
    }
}
