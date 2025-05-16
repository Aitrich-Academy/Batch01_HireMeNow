using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.Services.JobSeeker.Job.DTO
{
    public class InterviewDTO
    {
        public Guid? JobId { get; set; }

        public Guid? ApplicationId { get; set; }

        public Guid? ScheduledBy { get; set; }

        public Guid CompanyId { get; set; }
        
        public JobInterviewStatus Status { get; set; }
    }
}
