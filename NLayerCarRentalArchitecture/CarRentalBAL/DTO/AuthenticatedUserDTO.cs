﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBAL.DTO
{
    public class AuthenticatedUserDTO
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? UserId { get; set; }
        public string? Role { get; set; }
    }
}
