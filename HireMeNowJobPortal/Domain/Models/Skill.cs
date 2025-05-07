using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class Skill
{
    public Guid Id { get; set; } = new Guid();
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public virtual ICollection<JobSeekerProfileSkill> JobSeekerProfileSkills { get; set; }= new List<JobSeekerProfileSkill>();  
}




