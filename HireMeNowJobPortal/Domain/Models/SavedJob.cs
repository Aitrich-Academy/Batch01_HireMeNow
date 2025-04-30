using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class SavedJob
{
    public Guid Id { get; set; }

    public Guid Job { get; set; }

    public Guid SavedBy { get; set; }

    public DateTime DateSaved { get; set; }

    public virtual JobPost JobNavigation { get; set; } = null!;

    public virtual JobSeeker SavedByNavigation { get; set; } = null!;
}
