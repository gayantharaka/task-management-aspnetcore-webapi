﻿using System;
using System.ComponentModel.DataAnnotations;

namespace UserService.Dtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Full name is required.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8,ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }
    }
}