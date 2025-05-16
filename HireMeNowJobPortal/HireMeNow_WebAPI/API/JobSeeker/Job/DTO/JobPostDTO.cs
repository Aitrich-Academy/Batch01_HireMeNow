namespace HireMeNow_WebAPI.API.JobSeeker.Job.DTO
{
    public class JobPostDTO
    {
        public string? JobTitle { get; set; }
        public string? JobSummary { get; set; }
        public string? Location { get; set; }
        public string? CompanyName { get; set; }
        public string? CategoryName { get; set; }
        public string? IndustryName { get; set; }
        public DateTime PostedDate { get; set; }
    }
}
