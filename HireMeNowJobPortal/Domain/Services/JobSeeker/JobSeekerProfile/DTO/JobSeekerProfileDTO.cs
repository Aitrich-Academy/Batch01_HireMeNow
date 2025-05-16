using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobSeeker.JobSeekerProfile.DTO
{
    public class JobSeekerProfileDTO
    {
        public Guid? ResumeId { get; set; }
        public string? ProfileName { get; set; }
        public string? ProfileSummary { get; set; }
    }
}
