﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class JobPost
{
    public Guid Id { get; set; }
    public string JobTitle { get; set; } = null!;
    public string JobSummary { get; set; } = null!;

    [ForeignKey(nameof(Location))]
    public Guid? LocationId { get; set; }

    [ForeignKey(nameof(Company))]
    public Guid? CompanyId { get; set; }

    [ForeignKey(nameof(JobCategory))]
    public Guid? CategoryId { get; set; }

    [ForeignKey(nameof(Industry))]
    public Guid? IndustryId { get; set; }

    [ForeignKey(nameof(PostedByNavigation))]
    public Guid? PostedBy { get; set; }
    public DateTime PostedDate { get; set; }
    public virtual Location? Location { get; set; } = null!;
    public virtual JobProviderCompany? Company { get; set; } = null!;
    public virtual JobCategory? JobCategory { get; set; } = null!;
    public virtual Industry? Industry { get; set; } = null!;
    public virtual CompanyUser? PostedByNavigation { get; set; } = null!;
    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();
    public virtual ICollection<JobResponsibility> JobResponsibilities { get; set; } = new List<JobResponsibility>();
    public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
    public virtual ICollection<Qualification> Qualifications { get; set; } = new List<Qualification>();
    public virtual ICollection<SavedJob> SavedJobs { get; set; } = new List<SavedJob>();
  
}






    
