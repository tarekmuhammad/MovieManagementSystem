﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Application.DTO
{
    public class LoginDto
    {
        [
            Required(ErrorMessage = "Email is required."), 
            EmailAddress(ErrorMessage = "Invalid email address.")
        ]
        public string Email { get; set; }
        [
            Required(ErrorMessage = "Password is required."),
            MinLength(6, ErrorMessage = "Password must be at least 6 characters.")
        ]
        public string? Password { get; set; }

        public bool   RememberMe { get; set; }
    }
}
