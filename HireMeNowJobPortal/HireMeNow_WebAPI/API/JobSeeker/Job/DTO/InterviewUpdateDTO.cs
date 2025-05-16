using Domain.Enums;

namespace HireMeNow_WebAPI.API.JobSeeker.Job.DTO
{
    public class InterviewUpdateDTO
    {
        public Guid InterviewId { get; set; }
        public JobInterviewStatus Status { get; set; }
    }
}
