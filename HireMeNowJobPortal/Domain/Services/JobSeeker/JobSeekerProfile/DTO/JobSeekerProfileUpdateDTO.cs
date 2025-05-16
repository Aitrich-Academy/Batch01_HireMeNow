using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobSeeker.JobSeekerProfile.DTO
{
    public class JobSeekerProfileUpdateDTO
    {
        public Guid Id { get; set; }
        public Guid? ResumeId { get; set; }
        public string? ProfileName { get; set; }
        public string? ProfileSummary { get; set; }
    }
}
