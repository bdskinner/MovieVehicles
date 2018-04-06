using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieVehicles.Models;
using System.ComponentModel.DataAnnotations;


namespace MovieVehicles.ViewModels
{
    public class EditUserVM
    {
        #region CONSTRUCTOR(S)

        public EditUserVM()
        {

        }

        public EditUserVM(ApplicationUser user)
        {
            this.UserName = user.UserName;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.Email = user.Email;
            this.City = user.City;
            this.State = user.State;
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

        #endregion
    }
}