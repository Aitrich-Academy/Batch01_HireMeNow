using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Breed
{
    public Guid? Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid Category { get; set; }
}
