using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;


namespace Domain.Models
{
    public class JobApplication
    {
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

        [ForeignKey(nameof(JobPost))]
        public Guid JobPost_id {  get; set; }

        [ForeignKey(nameof(Seeker))]
        public Guid Applicant { get; set; }

        [ForeignKey(nameof(Resume))]
        public Guid Resume_id { get; set; }
        public string? CoverLetter { get; set; }
        public DateTime DateSubmitted { get; set; }
        public Status Status { get; set; }
        public virtual JobPost? JobPost { get; set; }
        public virtual JobSeeker? Seeker { get; set; }
        public virtual Resume? Resume { get; set; }
        public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();

    }
}



