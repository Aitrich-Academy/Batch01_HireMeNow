using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class JobApplication
{
    public Guid Id { get; set; }

    public Guid JobPostId { get; set; }

    public Guid Applicant { get; set; }

    public Guid ResumeId { get; set; }

    public string CoverLetter { get; set; } = null!;

    public DateTime Datesubmitted { get; set; }

    public int Status { get; set; }

    public virtual JobSeeker ApplicantNavigation { get; set; } = null!;

    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();

    public virtual JobPost JobPost { get; set; } = null!;

    public virtual Resume Resume { get; set; } = null!;
}
