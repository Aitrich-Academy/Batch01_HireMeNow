using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobSeeker.Job.DTO
{
    public class JobApplicationDTO
    {
        public Guid JobPostId { get; set; }

        public Guid ResumeId { get; set; }

        public string CoverLetter { get; set; } = null!;

       
    }
}
