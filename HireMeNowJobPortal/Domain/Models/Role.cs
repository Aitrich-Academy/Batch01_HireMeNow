﻿using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Role
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}


