using AutoMapper;
using Domain.Models;
using Domain.Services.Admin.Interfaces;
using Domain.Services.Login.Interfaces;
using HireMeNow_WebAPI.API.Admin.RequestObjects;
using HireMeNow_WebAPI.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNow_WebAPI.API.Admin
{
    
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class AdminController : BaseApiController<AdminController>
    {
        private readonly ILoginRequestService _loginRequestService;
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;
        public AdminController(ILoginRequestService loginRequestService, IAdminService adminService, IMapper mapper)
        {
            _loginRequestService = loginRequestService;
            _adminService = adminService;
            _mapper = mapper;
        }

        //Login

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login(AdminLoginRequests logdata)
        {

            var user = _loginRequestService.AdminLogin(logdata.Email, logdata.Password);

            if (user == null)
            {
                return BadRequest("Login Failed");
            }
            return Ok(user);
        }

        //Get Jobseekers

        [HttpGet("jobseekers")]
        public async Task<IActionResult> GetJobSeekers()
        {
            try
            {
                var jobSeekers = await _adminService.GetJobSeekers(); 
                return Ok(jobSeekers);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while fetching job seekers.");
            }
        }

        //GetJobseekerById

        [HttpGet("jobseekers/{id}")]
        public async Task<IActionResult> GetJobSeekerById(Guid id)
        {
            var jobSeeker = await _adminService.GetJobSeekerById(id);

            if (jobSeeker == null)
            {
                return NotFound(new { Message = $"Job seeker with ID {id} not found." });
            }

            return Ok(jobSeeker);
        }

        //GetJobSeekerCount

        [HttpGet("jobseekers/count")]
        public IActionResult GetJobSeekerCount()
        {
            try
            {
                var count = _adminService.GetJobSeekerCount();
                return Ok(new { Count = count });
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while retrieving the job seeker count.");
            }
        }

        //GetJobproviderCompanies

        [HttpGet("jobprovidercompanies")]
        public async Task<IActionResult> GetJobProviderCompanies()
        {
            try
            {
                var jobProviderCompanies = await _adminService.GetAllJobProviderCompanies();
                return Ok(jobProviderCompanies);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while fetching job provider companies.");
                //return BadRequest($"Exception: {ex.Message}");
            }
        }

        //GetJobProviderCompanyById

        [HttpGet("jobprovidercompanies/{id}")]
        public async Task<IActionResult> GetJobProviderCompanyById(Guid id)
        {
            var jobProviderCompany = await _adminService.GetJobProviderCompanyById(id);

            if (jobProviderCompany == null)
            {
                return NotFound(new { Message = $"Job provider company with ID {id} not found." });
            }

            return Ok(jobProviderCompany);
        }

        //GetJobProviderCompanyCount

        [HttpGet("jobprovidercompanies/count")]
        public IActionResult GetJobProviderCompanyCount()
        {
            try
            {
                var count = _adminService.GetJobProviderCompanyCount();
                return Ok(new { Count = count });
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while retrieving the job provider company count.");
            }
        }

        //SearchJobProviderCompanyByName

        [HttpGet("jobprovidercompanies/search")]
        public async Task<IActionResult> SearchJobProviderCompaniesByName([FromQuery] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest(new { Message = "Job Provider Company name  is required." });
            }

            var companies = await _adminService.SearchJobProviderCompanyByName(name);

            return Ok(companies);
        }

        //GetCompanyUsers

        [HttpGet("companyusers")]
        public async Task<IActionResult> GetCompanyUsers()
        {
            try
            {
                var companyUsers = await _adminService.GetCompanyUsers();
                return Ok(companyUsers);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while fetching company users.");
            }
        }

        //GetCompanyUsersById

        [HttpGet("companyusers/{id}")]
        public async Task<IActionResult> GetCompanyUserById(Guid id)
        {
            var companyUser = await _adminService.GetCompanyUserById(id);

            if (companyUser == null)
            {
                return NotFound(new { Message = $"Company user with ID {id} not found." });
            }

            return Ok(companyUser);
        }


        //GetCompanyUserCount

        [HttpGet("companyusers/count")]
        public IActionResult GetCompanyUserCount()
        {
            try
            {
                var count = _adminService.GetCompanyUserCount();
                return Ok(new { Count = count });
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while retrieving the company user count.");
            }
        }

        //GetAllJobPosts

        [HttpGet("jobposts")]
        public async Task<IActionResult> GetAllJobposts()
        {
            try
            {
                var jobPosts = await _adminService.GetAllJobPosts();
                return Ok(jobPosts);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while fetching job posts.");
            }
        }

        //GetJobPostsById

        [HttpGet("jobposts/{id}")]
        public async Task<IActionResult> GetJobPostsById(Guid id)
        {
            var jobPost = await _adminService.GetJobPostsById(id);

            if (jobPost == null)
            {
                return NotFound(new { Message = $"Job Post with ID {id} not found." });
            }

            return Ok(jobPost);
        }

        //GetJobPostCount


        [HttpGet("jobposts/count")]
        public IActionResult GetJobPostCount()
        {
            try
            {
                var count = _adminService.GetJobPostCount();
                return Ok(new { Count = count });
            }
            catch (Exception ex)
            {
                return Problem("An error occurred while retrieving the job post count.");
            }
        }

        //GetJobPostsByName

        [HttpGet("jobposts/search")]
        public async Task<IActionResult> GetJobPostsByName([FromQuery] string jobTitle)
        {
            if (string.IsNullOrWhiteSpace(jobTitle))
            {
                return BadRequest(new { Message = "JobTitle is required." });
            }

            var jobPosts = await _adminService.GetJobPostsByName(jobTitle);

            return Ok(jobPosts); 
        }

        //GetLocation

        [HttpGet("locations")]
        public async Task<IActionResult> GetLocations()
        {
            try
            {
                var locations = await _adminService.GetLocations();
                return Ok(locations);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while fetching locations.");
            }
        }

        //GetLocationById

        [HttpGet("locations/{id}")]
        public async Task<IActionResult> GetLocationById(Guid id)
        {
            var location = await _adminService.GetLocationById(id);

            if (location == null)
            {
                return NotFound(new { Message = $"Location with ID {id} not found." });
            }

            return Ok(location);
        }

        //AddLocation

        [HttpPost("locations")]
        public async Task<IActionResult> AddLocation([FromBody] LocationRequestAdmin location)
        {
            if (location == null)
            {
                return BadRequest(new { Message = "Location data is required." });
            }

            try
            {
                var locationEntity = _mapper.Map<Location>(location);
                var locationDto = await _adminService.AddLocation(locationEntity);
                return CreatedAtAction(nameof(GetLocationById), new { id = locationDto.Id }, locationDto);
            }
            catch (Exception ex)
            {
                 return Problem("An error occurred while adding the location.");
            }
        }
        ////UpdateLocation

        //[HttpPut("locations/{locationId}")]
        //public async Task<IActionResult> UpdateLocation([FromBody] LocationRequestAdmin updatedLocation, [FromRoute] Guid locationId)
        //{
        //    if (updatedLocation == null)
        //    {
        //        return BadRequest(new { Message = "Updated location data is required." });
        //    }

        //    try
        //    {
        //        var locationEntity = _mapper.Map<Location>(updatedLocation);

        //        var locationDto = await _adminService.UpdateLocation(locationEntity, locationId);

        //        if (locationDto == null)
        //        {
        //            return NotFound(new { Message = $"Location with ID {locationId} not found." });
        //        }

        //        return Ok(locationDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem("An error occurred while updating the location.");
        //    }
        //}

        ////RemoveLocationById

        //[HttpDelete("locations/{locationId}")]
        //public async Task<IActionResult> RemoveLocationById([FromRoute] Guid locationId)
        //{
        //    try
        //    {
        //        var deletedLocation = await _adminService.RemoveLocationById(locationId);

        //        if (deletedLocation == null)
        //        {
        //            return NotFound(new { Message = $"Location with ID {locationId} not found." });
        //        }

        //        return Ok(deletedLocation); 
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem("An error occurred while removing the location.");
                
        //        //var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
        //        //return BadRequest(new { Message = "Failed to delete location", Details = errorMessage });

        //    }
        //}


        ////GetSkills

        //[HttpGet("skills")]
        //public async Task<IActionResult> GetSkills()
        //{
        //    try
        //    {
        //        var skills = await _adminService.GetSkills();
        //        return Ok(skills);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("An error occurred while fetching skills.");
        //    }
        //}

        ////GetSkillsById

        //[HttpGet("skills/{id}")]
        //public async Task<IActionResult> GetSkillsById(Guid id)
        //{
        //    var skill = await _adminService.GetSkillsById(id);

        //    if (skill == null)
        //    {
        //        return NotFound(new { Message = $"Skill with ID {id} not found." });
        //    }

        //    return Ok(skill);
        //}


        ////AddSkill

        //[HttpPost("skills")]
        //public async Task<IActionResult> AddSkill([FromBody] SkillRequestAdmin skill)
        //{
        //    if (skill == null)
        //    {
        //        return BadRequest(new { Message = "Skill data is required." });
        //    }

        //    try
        //    {
        //        var skillEntity = _mapper.Map<Skill>(skill);
        //        var skillDto = await _adminService.AddSkill(skillEntity);
        //        return CreatedAtAction(nameof(GetSkillsById), new { id = skillDto.Id }, skillDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem("An error occurred while adding the skill.");
        //    }
        //}

        ////UpdateSkill

        //[HttpPut("skills/{skillId}")]
        //public async Task<IActionResult> UpdateSkill([FromBody] SkillRequestAdmin updatedSkill, [FromRoute] Guid skillId)
        //{
        //    if (updatedSkill == null)
        //    {
        //        return BadRequest(new { Message = "Updated skill data is required." });
        //    }

        //    try
        //    {
        //        var skillEntity = _mapper.Map<Skill>(updatedSkill);
        //        var skillDto = await _adminService.UpdateSkill(skillEntity, skillId);

        //        if (skillDto == null)
        //        {
        //            return NotFound(new { Message = $"Skill with ID {skillId} not found." });
        //        }

        //        return Ok(skillDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem("An error occurred while updating the skill.");
        //    }
        //}

        ////RemoveSkillById

        //[HttpDelete("skills/{skillId}")]
        //public async Task<IActionResult> RemoveSkillById([FromRoute] Guid skillId)
        //{
        //    try
        //    {
        //        var deletedSkill = await _adminService.RemoveSkillById(skillId);

        //        if (deletedSkill == null)
        //        {
        //            return NotFound(new { Message = $"Skill with ID {skillId} not found." });
        //        }

        //        return Ok(deletedSkill);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem("An error occurred while removing the skill.");
        //        //return BadRequest($"Exception: {ex.Message}");
        //    }
        //}

        ////GetIndustries

        //[HttpGet("industries")]
        //public async Task<IActionResult> GetIndustries()
        //{
        //    try
        //    {
        //        var industries = await _adminService.GetIndustries();
        //        return Ok(industries);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("An error occurred while fetching industries.");
        //    }
        //}

        ////GetIndustryById

        //[HttpGet("industries/{id}")]
        //public async Task<IActionResult> GetIndustryById(Guid id)
        //{
        //    var industry = await _adminService.GetIndustryById(id);

        //    if (industry == null)
        //    {
        //        return NotFound(new { Message = $"Industry with ID {id} not found." });
        //    }

        //    return Ok(industry);
        //}

        ////AddIndustry


        //[HttpPost("industries")]
        //public async Task<IActionResult> AddIndustry([FromBody] IndustryRequestAdmin industry)
        //{
        //    if (industry == null)
        //    {
        //        return BadRequest(new { Message = "Industry data is required." });
        //    }

        //    try
        //    {
        //        var industryEntity = _mapper.Map<Industry>(industry);
        //        var industryDto = await _adminService.AddIndustry(industryEntity);
        //        return CreatedAtAction(nameof(GetIndustryById), new { id = industryDto.Id }, industryDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem("An error occurred while adding the industry.");
        //    }
        //}

        ////UpdateIndustry

        //[HttpPut("industries/{industryId}")]
        //public async Task<IActionResult> UpdateIndustry([FromBody] IndustryRequestAdmin updatedIndustry, [FromRoute] Guid industryId)
        //{
        //    if (updatedIndustry == null)
        //    {
        //        return BadRequest(new { Message = "Updated industry data is required." });
        //    }

        //    try
        //    {
        //        var industryEntity = _mapper.Map<Industry>(updatedIndustry);
        //        var industryDto = await _adminService.UpdateIndustry(industryEntity, industryId);

        //        if (industryDto == null)
        //        {
        //            return NotFound(new { Message = $"Industry with ID {industryId} not found." });
        //        }

        //        return Ok(industryDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem("An error occurred while updating the industry.");
        //    }
        //}


        ////RemoveIndustryById

        //[HttpDelete("industries/{industryId}")]
        //public async Task<IActionResult> RemoveIndustryById([FromRoute] Guid industryId)
        //{
        //    try
        //    {
        //        var deletedIndustry = await _adminService.RemoveIndustryById(industryId);

        //        if (deletedIndustry == null)
        //        {
        //            return NotFound(new { Message = $"Industry with ID {industryId} not found." });
        //        }

        //        return Ok(deletedIndustry);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem("An error occurred while removing the industry.");
        //    }
        //}

        ////GetJobCategories

        //[HttpGet("jobcategories")]
        //public async Task<IActionResult> GetJobCategories()
        //{
        //    try
        //    {
        //        var categories = await _adminService.GetJobCategories();
        //        return Ok(categories);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("An error occurred while fetching categories.");
        //    }
        //}

        ////GetJobCategoriesById

        //[HttpGet("jobcategories/{id}")]
        //public async Task<IActionResult> GetJobCategoryById(Guid id)
        //{
        //    var category = await _adminService.GetJobCategoryById(id);

        //    if (category == null)
        //    {
        //        return NotFound(new { Message = $"Job category with ID {id} not found." });
        //    }

        //    return Ok(category);
        //}

        ////AddJobCategory


        //[HttpPost("jobcategories")]
        //public async Task<IActionResult> AddCategory([FromBody] JobCategoryRequestAdmin category)
        //{
        //    if (category == null)
        //    {
        //        return BadRequest(new { Message = "Job category data is required." });
        //    }

        //    try
        //    {
        //        var categoryEntity = _mapper.Map<JobCategory>(category);
        //        var categoryDto = await _adminService.AddJobCategory(categoryEntity);
        //        return CreatedAtAction(nameof(GetJobCategoryById), new { id = categoryDto.Id }, categoryDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem("An error occurred while adding the job category.");
        //    }
        //}

        ////UpdateJobCategory


        //[HttpPut("jobcategories/{jobcategoryId}")]
        //public async Task<IActionResult> UpdateJobcategory([FromBody] JobCategoryRequestAdmin updatedCategory,[FromRoute] Guid jobcategoryId)
        //{
        //    if (updatedCategory == null)
        //    {
        //        return BadRequest(new { Message = "Updated job category data is required." });
        //    }

        //    try
        //    {
        //        var categoryEntity = _mapper.Map<JobCategory>(updatedCategory);
        //        var categoryDto = await _adminService.UpdateJobCategory(categoryEntity, jobcategoryId);

        //        if (categoryDto == null)
        //        {
        //            return NotFound(new { Message = $"Category with ID {jobcategoryId} not found." });
        //        }

        //        return Ok(categoryDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem("An error occurred while updating the job category.");
        //    }
        //}

        ////RemoveJobCategoryById

        //[HttpDelete("jobcategories/{jobcategoryId}")]
        //public async Task<IActionResult> RemoveJobcategoryById([FromRoute] Guid jobcategoryId)
        //{
        //    try
        //    {
        //        var deletedCategory = await _adminService.RemoveJobCategoryById(jobcategoryId);

        //        if (deletedCategory == null)
        //        {
        //            return NotFound(new { Message = $"Job Category with ID {jobcategoryId} not found." });
        //        }

        //        return Ok(deletedCategory);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem("An error occurred while removing the job category.");
        //    }
        //}

    }
}
