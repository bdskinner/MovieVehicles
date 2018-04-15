using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieVehicles.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieVehicles.ViewModels
{
    public class CreateUserVM
    {
        #region CONSTRUCTOR(S)

        public CreateUserVM()
        {

        }

        public CreateUserVM(ApplicationUser user)
        {
            this.UserName = user.UserName;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.City = user.City;
            this.State = user.State;
            this.Email = user.Email;
            this.Password = user.PasswordHash;
        }

        #endregion

        #region PROPERTIES 

        [Key]
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }
        
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        
        #endregion
    }
}