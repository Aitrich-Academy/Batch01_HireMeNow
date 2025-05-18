using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobProvider.Dtos
{
	public class SheduledInterviewDto
	{
        public Guid Id { get; set; }
        public string JobJobTitle { get; set; }
        public string JobseekerUsername { get; set; }

        public Guid ApplicationId { get; set; }

        public DateTime? Date { get; set; }


        public JobInterviewStatus Status { get; set; }
        public string CompanyUserUserName { get; set; }

      
       
    }
}
