namespace HireMeNow_WebAPI.API.JobProvider.RequestObjects
{
    public class JobPostRequest
    {
        public string JobTitle { get; set; } = null!;

        public string JobSummary { get; set; } = null!;
        public Guid LocationId { get; set; }

        public Guid CompanyId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid IndustryId { get; set; }

        public Guid PostedBy { get; set; }

        public DateTime PostedDate { get; set; }
    }
}
