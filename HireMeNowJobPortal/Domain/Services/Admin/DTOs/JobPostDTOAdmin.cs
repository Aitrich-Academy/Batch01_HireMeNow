using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Admin.DTOs
{
    public class JobPostDTOAdmin
    {
        public string JobTitle { get; set; } = null!;
        public string JobSummary { get; set; } = null!;
        public string? LocationName { get; set; }
        public string? CompanyName { get; set; }
        public string? CategoryName { get; set; }
        public string? IndustryName { get; set; }
        public string? PostedByName { get; set; }
        public DateTime PostedDate { get; set; }
    }
}





