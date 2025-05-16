using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobSeeker.JobSeekerProfile.DTO
{
    public class QualificationDTO
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid? JobseekerProfileId { get; set; }
    }
}
