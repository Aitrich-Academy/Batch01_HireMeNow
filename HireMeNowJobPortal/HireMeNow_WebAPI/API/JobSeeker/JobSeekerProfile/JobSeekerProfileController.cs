using AutoMapper;
using Domain.Models;
using Domain.Services.AuthUser.Interfaces;
using Domain.Services.JobSeeker.JobSeekerProfile.DTO;
using Domain.Services.JobSeeker.JobSeekerProfile.Interfaces;
using HireMeNow_WebAPI.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNow_WebAPI.API.JobSeeker.JobSeekerProfile
{
    [ApiController]
    [Authorize(Roles = "JOB_SEEKER")]
    public class JobSeekerProfileController : BaseApiController<JobSeekerProfileController>
    {
        private readonly IJobSeekerService _jobSeekerService;
        public IMapper _mapper;
        private readonly IAuthUserService _authUserService;
        public JobSeekerProfileController(IJobSeekerService jobSeekerService,IMapper mapper, IAuthUserService authUserService)
        {
            _jobSeekerService = jobSeekerService;
            _mapper = mapper;
            _authUserService = authUserService;
        }

        [HttpPost("CreateProfile")]
        public async Task<IActionResult> CreateJobSeekerProfile(JobSeekerProfileDTO jobSeekerProfileDTO)
        {
            var jobseekerId= new Guid(_authUserService.GetUserId());
            var addProfile = new Domain.Models.JobSeekerProfile
            {
                JobSeekerId=jobseekerId,
                ResumeId = jobSeekerProfileDTO.ResumeId,
                ProfileName=jobSeekerProfileDTO.ProfileName,
                ProfileSummary=jobSeekerProfileDTO.ProfileSummary,

            };
            await _jobSeekerService.CreateJobSeekerProfile(addProfile);
            return Ok();
          
        }

        [HttpPut("UpdateProfile{profileId:guid}")]
        public async Task<IActionResult> updateProfile([FromForm]JobSeekerProfileUpdateDTO jobSeekerProfile)
        {
            var updateProfile = _mapper.Map<Domain.Models.JobSeekerProfile>(jobSeekerProfile);
            await _jobSeekerService.UpdateJobSeekerProfile(updateProfile);
            return Ok("Profile updated successfully");
        }

        [HttpGet("GetProfile{profileId:guid}")]
        public async Task<IActionResult> GetProfile(Guid profileId)
        {
            var profile=await _jobSeekerService.GetJobSeekerProfile(profileId);
            var getSeekerProfile=_mapper.Map<JobSeekerProfileDTO>(profile);
            return Ok(getSeekerProfile);
        }

        [HttpDelete("DeleteProfile{profileId:guid}")]
        public async Task<IActionResult> DeleteProfile(Guid profileId)
        {
            await _jobSeekerService.DeleteJobSeekerProfile(profileId);
            return Ok("Profile deleted successfully");
        }

        [HttpPost("AddResume")]
        public async Task<IActionResult> AddResume(ResumeDTO resumeDTO)
        {
            var jobSeekerId= new Guid(_authUserService.GetUserId());
            if (resumeDTO.File == null || resumeDTO.File.Length == 0)
            {
                return BadRequest("Resume file is missing.");
            }
            var memoryStream = new MemoryStream();
            await resumeDTO.File.CopyToAsync(memoryStream);
            byte[] fileData = memoryStream.ToArray();
            var newResume = new Domain.Models.Resume
            {
                Id = Guid.NewGuid(),
                Title = resumeDTO.Title,
                File = fileData,
                JobSeekerId = jobSeekerId
            };
            await _jobSeekerService.AddResume(newResume);
            return Ok("Resume uploaded successfully.");
        }

        [HttpGet("GetResumeById{profileId:guid}")]
        public async Task<IActionResult> GetResumeById(Guid profileId)
        {
            var selectedResume=await _jobSeekerService.GetResumeById(profileId);
            if (selectedResume == null)
            {
                return BadRequest("Not found");
            }
            var seekerResume=_mapper.Map<ResumeViewDTO>(selectedResume);
            return Ok(seekerResume);
            
        }

        [HttpGet("GetAllResume{jobSeekerId:guid}")]
        public async Task<IActionResult> GetAllResume(Guid jobSeekerId)
        {
            var allResume=await _jobSeekerService.GetResumes(jobSeekerId);
            if (allResume == null)
            {
                return BadRequest("No resume added");
            }
            var resumeList=_mapper.Map<List<ResumeViewDTO>>(allResume);
            return Ok(resumeList);
        }

        [HttpPut("UpdateResume{resumeId:guid}")]
        public async Task<IActionResult> UpdateResume(Guid resumeId,ResumeDTO resumeDTO)
        {
            Guid jobseekerId = new Guid(_authUserService.GetUserId());
            if (resumeDTO.File == null || resumeDTO.File.Length == 0)
            {
                return BadRequest("Resume file is missing.");
            }
            var memoryStream = new MemoryStream();
            await resumeDTO.File.CopyToAsync(memoryStream);
            byte[] fileData = memoryStream.ToArray();
            var newResume = new Domain.Models.Resume
            {
                Id = resumeId,
                Title = resumeDTO.Title,
                File = fileData,
                JobSeekerId=jobseekerId,
                
            };
            await _jobSeekerService.UpdateResume(newResume);
            return Ok("Resume updated successfully.");
        }
        [HttpDelete("DeleteResume{resumeId:guid}")]
        public async Task<IActionResult> DeleteResume(Guid resumeId)
        {
            await _jobSeekerService.DeleteResume(resumeId);
            return Ok("Resume deleted successfully");
        }

        [HttpPost("AddSkill{skillId:guid}")]
        public async Task<IActionResult> AddSkill(Guid skillId)
        {
            var jobSeekerProfileId = _authUserService.GetUserProfileId();
            var newSkill = new JobSeekerProfileSkill
            {
                JobSeekerProfileId = jobSeekerProfileId,
                SkillId = skillId,
            };
            await _jobSeekerService.AddJobSeekerSkills(newSkill);
            return Ok("Skill added successfully");
            
        }
        [HttpDelete("DeleteSkill{skillId:guid}")]
        public async Task<IActionResult> DeleteSkill(Guid skillId)
        {
            var profileId= _authUserService.GetUserProfileId();
            await _jobSeekerService.DeleteJobSeekerSkills(profileId,skillId);
            return Ok("Skill deleted");
        }

        [HttpGet("JobSeekerProfileSkills")]
        public async Task<IActionResult> GetProfileSkill()
        {
            Guid profileId= _authUserService.GetUserProfileId();
            var seekerSkills=await _jobSeekerService.GetJobSeekerSkills(profileId);
            var profileSkills=_mapper.Map<List<JobSeekerSkillDTO>>(seekerSkills);
            return Ok(profileSkills);
        }

        [HttpPost("AddExperience")]
        public async Task<IActionResult> AddExperience(JobSeekerExperienceDTO seekerExperienceDTO)
        {
            Guid profileId= _authUserService.GetUserProfileId();
            var newExperience = new WorkExperience
            {
                Id=Guid.NewGuid(),
                JobSeekerProfileId = profileId,
                JobTitle = seekerExperienceDTO.JobTitle,
                CompanyName = seekerExperienceDTO.CompanyName,
                Summary = seekerExperienceDTO.Summary,
                ServiceStart = seekerExperienceDTO.ServiceStart,
                ServiceEnd = seekerExperienceDTO.ServiceEnd,
            };
            await _jobSeekerService.AddWorkExperience(newExperience);
            return Ok("New experience added.");
        }
        [HttpGet("GetAllExperience")] 
        public async Task<IActionResult> GetAllExperience()
        {
            Guid profileId= _authUserService.GetUserProfileId();
            var experiences=await _jobSeekerService.GetAllWorkExperience(profileId);
            var seekerExperience=_mapper.Map<List<JobSeekerExperienceDTO>>(experiences);
            return Ok(seekerExperience);
        }

        [HttpPut("UpdateExperience{experienceId:guid}")]
        public async Task<IActionResult> UpdateExperience(Guid experienceId,JobSeekerExperienceDTO seekerExperienceDTO)
        {
            var updatingExperience = new WorkExperience
            {
                JobSeekerProfileId = _authUserService.GetUserProfileId(),
                Id = experienceId,
                JobTitle = seekerExperienceDTO.JobTitle,
                CompanyName = seekerExperienceDTO.CompanyName,
                Summary = seekerExperienceDTO.Summary,
                ServiceStart = seekerExperienceDTO.ServiceStart,
                ServiceEnd = seekerExperienceDTO.ServiceEnd,
            };
            await _jobSeekerService.UpdateWorkExperience(updatingExperience);
            return Ok("Experience updated successfully \n");
        }

        [HttpDelete("DeleteExperience{workExperienceId:guid}")]
        public async Task<IActionResult> DeleteExperience(Guid workExperienceId)
        {
            Guid profileId= _authUserService.GetUserProfileId();
            await _jobSeekerService.DeleteWorkExperience(profileId,workExperienceId);
            return Ok("Work experience deleted successfully");
        }

        [HttpPost("AddQualification")]
        public async Task<IActionResult> AddQualification(JobSeekerQualificationDTO qualificationDTO)
        {
            Guid profileId= _authUserService.GetUserProfileId();
            var newQualification = new QualificationDTO
            {
                JobseekerProfileId = profileId,
                Name = qualificationDTO.Name,
                Description = qualificationDTO.Description,
            };
            var qualification=_mapper.Map<Qualification>(newQualification);
            await _jobSeekerService.AddJobSeekerQualification(qualification);
            return Ok("Qualification added");
        }

        [HttpGet("GetQualification")]
        public async Task<IActionResult> GetAllQualification()
        {
            Guid profileId = _authUserService.GetUserProfileId();
            var qualification=await _jobSeekerService.GetAllQualifications(profileId);
            var jobseekerQualification=_mapper.Map<List<JobSeekerQualificationDTO>>(qualification);
            return Ok(jobseekerQualification);
        }

        [HttpPut("UpdateQualification{qualificationId:guid}")]
        public async Task<IActionResult> UpdateQualification(Guid qualificationId,QualificationDTO qualification)
        {
            Guid profileId=_authUserService.GetUserProfileId();
            var updateQualification = new UpdateQualificationDTO
            {
                Id = qualificationId,
                JobseekerProfileId = profileId,
                Name = qualification.Name,
                Description = qualification.Description,
            };
            var updatedQualification=_mapper.Map<Qualification>(updateQualification);
            await _jobSeekerService.UpdateJobSeekerQualification(updatedQualification);
            return Ok("Qualification updated successfully");
        }

        [HttpDelete("DeleteQualification{qualificationId:guid}")]
        public async Task<IActionResult> DeleteQualification(Guid qualificationId)
        {
            Guid profileId= _authUserService.GetUserProfileId();
            await _jobSeekerService.DeleteJobSeekerQualification(profileId, qualificationId);
            return Ok("Qualification deleted successfully");
        }
    }
}
