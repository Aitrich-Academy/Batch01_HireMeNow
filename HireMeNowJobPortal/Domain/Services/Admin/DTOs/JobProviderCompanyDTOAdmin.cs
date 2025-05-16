using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Admin.DTOs
{
    public class JobProviderCompanyDTOAdmin
    {
        public string LegalName { get; set; } = null!;
        public string? Summary { get; set; }
        public string? IndustryName { get; set; }
        public string? LocationName { get; set; }
        public string Email { get; set; } = null!;
        public long Phone { get; set; }
        public string Address { get; set; } = null!;
        public string? Website { get; set; }
    }
}


