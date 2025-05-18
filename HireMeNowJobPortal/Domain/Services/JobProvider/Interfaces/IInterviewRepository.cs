
using Domain.Models;
using Domain.Service.JobProvider.Dtos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider.Interfaces
{

	public interface IInterviewRepository
	{
		Interview shduleInterview(InterviewsheduleDtos interview, CompanyUser user);
		bool removeInterview(Guid id);


        int GetTotalInterviewCount();


    }
}
