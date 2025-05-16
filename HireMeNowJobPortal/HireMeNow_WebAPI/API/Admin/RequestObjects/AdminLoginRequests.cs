using System.ComponentModel.DataAnnotations;

namespace HireMeNow_WebAPI.API.Admin.RequestObjects
{
    public class AdminLoginRequests
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
