﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage = "Please enter your username")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage ="Please enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a strong password")]
        [Compare("ConfirmPassword", ErrorMessage ="Password does not match")]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
