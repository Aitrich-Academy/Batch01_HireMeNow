using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Interview
{
    public Guid Id { get; set; }

    public Guid? JobId { get; set; }

    public Guid? Interviewee { get; set; }

    public Guid? ApplicationId { get; set; }

    public DateTime? Date { get; set; }

    public int Status { get; set; }

    public Guid? SheduledBy { get; set; }

    public Guid CompanyId { get; set; }

    public virtual JobApplication? Application { get; set; }

    public virtual JobProviderCompany Company { get; set; } = null!;

    public virtual JobSeeker? IntervieweeNavigation { get; set; }

    public virtual JobPost? Job { get; set; }

    public virtual CompanyUser? SheduledByNavigation { get; set; }
}
