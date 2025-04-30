using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class JobPost
{
    public Guid Id { get; set; }

    public string JobTitle { get; set; } = null!;

    public string JobSummary { get; set; } = null!;

    public Guid LocationId { get; set; }

    public Guid CompanyId { get; set; }

    public Guid CategoryId { get; set; }

    public Guid IndustryId { get; set; }

    public Guid PostedBy { get; set; }

    public DateTime PostedDate { get; set; }

    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();

    public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();

    public virtual ICollection<JobResponsibility> JobResponsibilities { get; set; } = new List<JobResponsibility>();

    public virtual Location Location { get; set; } = null!;

    public virtual CompanyUser PostedByNavigation { get; set; } = null!;

    public virtual ICollection<Qualification> Qualifications { get; set; } = new List<Qualification>();

    public virtual ICollection<SavedJob> SavedJobs { get; set; } = new List<SavedJob>();
}
