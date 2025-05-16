using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Admin.DTOs
{
    public class JobSeekerDTOAdmin
    {
        public string? UserName { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}




