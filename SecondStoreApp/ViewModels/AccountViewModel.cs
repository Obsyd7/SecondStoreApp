using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecondStoreApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required. Try again.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required. Try again.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "{0} requires at least {2} letters.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = " Password ")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password ")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }

}