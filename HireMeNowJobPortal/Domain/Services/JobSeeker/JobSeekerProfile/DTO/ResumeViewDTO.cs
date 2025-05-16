using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobSeeker.JobSeekerProfile.DTO
{
    public class ResumeViewDTO
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public byte[]? File { get; set; }
    }
}
