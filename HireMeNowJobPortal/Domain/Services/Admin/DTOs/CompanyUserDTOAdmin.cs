﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Admin.DTOs
{
    public class CompanyUserDTOAdmin
    {
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? CompanyName { get; set; }
    }
}

