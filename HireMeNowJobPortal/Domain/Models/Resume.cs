using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Models;

public partial class Resume
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public byte[]? File { get; set; }

    [ForeignKey(nameof(JobSeeker))]
    public Guid? JobSeekerId { get; set; }
    public virtual JobSeeker? JobSeeker {  get; set; }

    [JsonIgnore]
    public virtual ICollection<JobSeekerProfile> JobSeekerProfiles { get; set; } = new List<JobSeekerProfile>();
    public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
}




