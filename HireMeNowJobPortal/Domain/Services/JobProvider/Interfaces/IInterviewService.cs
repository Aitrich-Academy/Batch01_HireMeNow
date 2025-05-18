//using Domain.Helpers;
using Domain.Models;
using Domain.Services.JobProvider.Dtos;


//using HireMeNow_WebApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobProvider.Interfaces
{
	public interface IInterviewService
	{
		Interview sheduleinterview(InterviewsheduleDtos interview, CompanyUser userId);
		bool removeInterview(Guid id);

        int GetTotalInterviewCount();

    }
}
