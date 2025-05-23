﻿using System.ComponentModel.DataAnnotations;

namespace HireMeNow_WebAPI.API.JobSeeker.JobSeekerCredentials.Requests
{
    public class JobSeekerLoginRequest
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
