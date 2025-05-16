using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobSeeker.JobSeekerProfile.DTO
{
    public class ResumeDTO
    {
        public string? Title { get; set; }
        public IFormFile? File { get; set; }
    }
}
