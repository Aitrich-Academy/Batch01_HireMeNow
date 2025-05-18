using AutoMapper;
using Domain.Helpers;
using Domain.Models;

using Domain.Service.JobProvider.Dtos;
using Domain.Service.JobProvider.Interfaces;
using Domain.Services.AuthUser.Interfaces;
using HireMeNow_WebApi.API.JobProvider.RequestObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNow_WebApi.API.JobProvider
{
	[Route("api/[controller]")]
	[ApiController]
  	[Authorize(Roles = "COMPANY_USER")]
	public class InterviewController : ControllerBase

	{
		public InterviewController(IMapper _mapper,IInterviewService _interviewService,IAuthUserService _authUserService)
		{
			mapper = _mapper;
			interviewService = _interviewService;
			authUserService = _authUserService;
		}
		public IAuthUserService authUserService { get; set; }
		public IMapper mapper { get; set; }
		public IInterviewService interviewService { get; set; }
		[AllowAnonymous]
		[HttpPost]
		[Route("company/company-user/{companyuserid}/Interview")]
		public async Task<ActionResult> SheduleInterview(InterviewSheduleObject interviewSheduleObject,Guid companyuserid)
		{
			
			var user = authUserService.GetUser(companyuserid);
			if (user == null)
			{
				return BadRequest("No User");
			}

			var interviewDto = mapper.Map<InterviewsheduleDtos>(interviewSheduleObject);

			Interview interview=interviewService.sheduleinterview(interviewDto, user);

			return Ok("Interview scheduled successfully");

		}
       
        [AllowAnonymous]
		[HttpDelete]
		[Route("company/company-user/{intererviewid}/cancel")]
		public async Task<ActionResult> cancelInterview(Guid intererviewid)
		{
			var result=interviewService.removeInterview(intererviewid);	
			if(result==true)
			{
				return Ok("Successfully cancel the interview");
			}
			else
			{
				return BadRequest();
			}
		}


        [AllowAnonymous]
        [HttpGet]
        [Route("company/interview-count")]
        public ActionResult<int> GetInterviewCount()
        {
            int count = interviewService.GetTotalInterviewCount();
            return Ok(count);
        }

    }

}
