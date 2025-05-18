//using Domain.Helpers;
using Domain.Models;
using Domain.Services.JobProvider.Dtos;
using Domain.Services.JobProvider.Interfaces;


//using HireMeNow_WebApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobProvider
{
	public class InterviewService:IInterviewService
	{
		public InterviewService(IInterviewRepository _interviewRepository)
		{
			interviewRepository = _interviewRepository;
		}

		public IInterviewRepository interviewRepository { get; set; }
		public Interview sheduleinterview(InterviewsheduleDtos interview, CompanyUser userId)
		{
			return interviewRepository.shduleInterview(interview,userId);
		}
	
		public bool removeInterview(Guid id)
		{
			return interviewRepository.removeInterview(id);
		}

    


        public int GetTotalInterviewCount()
        {
            return interviewRepository.GetTotalInterviewCount();
        }

    }
}
