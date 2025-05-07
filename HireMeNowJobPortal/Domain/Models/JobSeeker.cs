using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public partial class JobSeeker
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string FirstName { get; set; } = null!;
    public string? LastName { get; set; }
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public byte[]? Image { get; set; } = null!;
    public Role? Role { get; set; }
    public virtual ICollection<JobSeekerProfile> JobSeekerProfiles { get; set; } = new List<JobSeekerProfile>();
    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();
    public virtual ICollection<SavedJob> SavedJobs { get; set; } = new List<SavedJob>();
    public virtual ICollection<JobApplication> JobApplications { get; set; } = new List<JobApplication>();
    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}











