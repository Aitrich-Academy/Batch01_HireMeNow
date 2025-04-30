using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class CompanyUser
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public int Role { get; set; }

    public string? UserName { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public Guid? Company { get; set; }

    public virtual JobProviderCompany? CompanyNavigation { get; set; }

    public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();

    public virtual ICollection<JobPost> JobPosts { get; set; } = new List<JobPost>();
}
