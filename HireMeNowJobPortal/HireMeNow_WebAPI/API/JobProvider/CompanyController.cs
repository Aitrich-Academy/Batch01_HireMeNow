using AutoMapper;
using Domain.Helpers;


using Domain.Service.SignUp.DTOs;
using Domain.Services.AuthUser.Interfaces;
using Domain.Services.JobProvider.Dtos;
using Domain.Services.JobProvider.DTOs;
using Domain.Services.JobProvider.Interfaces;
using HireMeNow_WebAPI.API.JobProvider.RequestObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HireMeNow_WebAPI.API.JobProvider
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "JOB_PROVIDER")]
    public class CompanyController : ControllerBase
    {
        public CompanyController(IMapper _mapper, ICompanyService _companyService, IAuthUserService _authUserService)
        {
            mapper = _mapper;
            companyService = _companyService;
            authUserService = _authUserService;
        }

        public IMapper mapper { get; set; }
        public ICompanyService companyService { get; set; }
        public IAuthUserService authUserService { get; set; }

        [HttpPost]
        [Route("job-provider/{jobproviderId}/company")]

        public async Task<ActionResult> AddCompany(Guid jobproviderId, AddCompanyRequestobject data)
        {
            var UserId = authUserService.GetUserId();
            var companyRegistrationDtos = mapper.Map<CompanyRegistrationDtos>(data);

           var company = await companyService.AddCompany(companyRegistrationDtos, new Guid(UserId));
            return Ok(company);

        }

        [AllowAnonymous]
        [HttpGet]
        [Route("job-provider/company/{companyId}")]
        public async Task<ActionResult> getCompany(Guid companyId)
        {
            var company = companyService.GetCompany(companyId);
            if (company == null)
            {
                return BadRequest("Company Not found");

            }
            else
            {
                return Ok(company);
            }


        }

        [AllowAnonymous]
        [HttpGet]
        [Route("job-provider/companies")]
        public async Task<ActionResult> GetAllCompanies()
        {
            var companies = await companyService.GetAllCompaniesAsync();
            if (companies == null || companies.Count == 0)
                return NotFound("No companies found");

            return Ok(companies);
        }


        [AllowAnonymous]
        [HttpPut]
        [Route("job-provider/company/{companyId}")]
        public async Task<ActionResult> UpdateCompany(Guid companyId, CompanyupdateRequest comapny)
        {
            if (companyId == null)
            {
                return BadRequest("Id is Required");
            }
            comapny.Id = companyId;
            var companyUpdateDtos = mapper.Map<CompanyUpdateDtos>(comapny);
            var updatedCompany = await companyService.UpdateAsync(companyUpdateDtos);
            if (updatedCompany == null)
            {
                return BadRequest("Company Not found");

            }
            else
            {
                return Ok(updatedCompany);
            }

        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("job-provider/company/{companyId}")]
        public async Task<IActionResult> DeleteCompany(Guid companyId)
        {
            var result = await companyService.DeleteCompanyAsync(companyId);
            if (result)
                return Ok("Company deleted successfully");
            else
                return NotFound("Company not found");
        }


      



        [AllowAnonymous]
        [HttpPost]
        [Route("job-provider/company/{companyId}/addcompanymember")]
        public async Task<ActionResult> AddCompanyMember(companyUserRequest request, Guid companyId)
        {
            try
            {
                var companyMemberDtos = mapper.Map<CompanyMemberDtos>(request);
                var member = await companyService.addMember(companyMemberDtos, companyId);
                return Ok(member);
            }
            catch (Exception exe)
            {
                return BadRequest(exe.Message);
            }
        }

    
        [AllowAnonymous]
        [HttpDelete]
        [Route("job-provider/company/{companyMemberId}/RemoveCompanyMember")]
        public IActionResult memberDelete(Guid companyMemberId)
        {
            var result = companyService.memberDeleteById(companyMemberId);
            if (result == true)
            {
                return Ok("Success fully remove the companyMember");

            }
            else
            {
                return BadRequest();
            }
        }

    }
}
