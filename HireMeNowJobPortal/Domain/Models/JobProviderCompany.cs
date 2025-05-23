﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public partial class JobProviderCompany
{
	[Key]
	[Required]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public Guid Id { get; set; } = Guid.NewGuid();
    public string LegalName { get; set; } = null!;
    public string Summary { get; set; } = null!;

    [ForeignKey(nameof(Industry))]
    public Guid? IndustryId { get; set; }

    [ForeignKey(nameof(LocationNavigation))]
    public Guid? LocationId { get; set; }
    public string Email { get; set; } = null!;
    public long Phone { get; set; }
    public string Address { get; set; } = null!;
    public string Website { get; set; } = null!;
    public virtual Industry? Industry { get; set; }
    public virtual Location? LocationNavigation { get; set; }
    public virtual ICollection<CompanyUser> CompanyUsers { get; set; } = new List<CompanyUser>();
    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();
    public virtual ICollection<JobPost> JobPosts { get; set; } = new List<JobPost>();

}







