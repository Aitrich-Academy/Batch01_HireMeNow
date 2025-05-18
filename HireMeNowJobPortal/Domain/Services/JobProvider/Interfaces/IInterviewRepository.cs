
using Domain.Models;
using Domain.Services.JobProvider.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.JobProvider.Interfaces
{

	public interface IInterviewRepository
	{
		Interview shduleInterview(InterviewsheduleDtos interview, CompanyUser user);
		bool removeInterview(Guid id);


        int GetTotalInterviewCount();


    }
}
