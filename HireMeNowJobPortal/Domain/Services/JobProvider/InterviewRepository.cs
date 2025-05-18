using AutoMapper;
using Domain.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using Domain.Services.JobProvider.Dtos;
using Domain.Services.JobProvider.Interfaces;


namespace Domain.Services.JobProvider
{
	public class InterviewRepository:IInterviewRepository
	{
		DbHireMeNowWebApiContext context;
		public IMapper mapper { get; set; }

		public InterviewRepository(DbHireMeNowWebApiContext context,IMapper _mapper)
		{
			this.context = context;
			mapper= _mapper;
		}

		public Interview shduleInterview(InterviewsheduleDtos interview, CompanyUser user)

		{
			try
			{
				JobApplication applicaction = context.JobApplications.Where(a => a.Id == interview.ApplicationId).Include(e => e.JobPost).FirstOrDefault();
				var interviewtoshedule = mapper.Map<Interview>(interview);
				interviewtoshedule.JobId = applicaction.JobPost_id;
				interviewtoshedule.ApplicationId = applicaction.Id;
				interviewtoshedule.Status = JobInterviewStatus.SCHEDULED;
				interviewtoshedule.ScheduledBy = user.Id;
				interviewtoshedule.Interviewee = applicaction.Applicant;
				interviewtoshedule.CompanyId = (Guid)user.Company;


				context.Interviews.AddAsync(interviewtoshedule);
				context.SaveChanges();
				return interviewtoshedule;

			}
			catch (Exception ex)
			{
				throw ex;
			}


		}
      
        public bool removeInterview(Guid id)
		{
			Interview interview = context.Interviews.FirstOrDefault(e => e.Id == id);
			if (interview != null)
			{
				context.Interviews.Remove(interview);
				context.SaveChanges();
				return true;
			}
			else
			{
				return false;
			}

		}



        public int GetTotalInterviewCount()
        {
            return context.Interviews.Count();
        }

    }
}
