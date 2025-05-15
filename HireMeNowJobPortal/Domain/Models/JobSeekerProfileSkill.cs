using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class JobSeekerProfileSkill
    {
        public Guid JobSeekerProfileId { get; set; }
        public Guid SkillId { get; set; }
        public virtual JobSeekerProfile? JobSeekerProfile { get; set; }
        public virtual Skill? Skill { get; set; }
    }
}



