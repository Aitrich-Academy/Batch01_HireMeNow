using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class Skill
{
    public Guid Id { get; set; } = new Guid();
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    [ForeignKey(nameof(JobPost))]
    public Guid Job { get; set; }

    [ForeignKey(nameof(JobSeekerNavigation))]
    public Guid SeekerId { get; set; }
    public virtual JobPost? JobPost { get; set; }
    public virtual JobSeeker? JobSeekerNavigation { get; set; }
}




