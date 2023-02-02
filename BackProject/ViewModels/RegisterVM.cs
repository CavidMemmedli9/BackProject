﻿using System.ComponentModel.DataAnnotations;

namespace BackProject.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords uyğun gəlmir")]
        [Display(Name = "Repeat Password")]
        public string PasswordConfirm { get; set; }

    }
}