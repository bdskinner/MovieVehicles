using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieVehicles.Models
{
    public class Review
    {
        #region FIELD(S)       

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Review Date")]
        public DateTime ReviewDate { get; set; }

        public int ReviewID { get; set; }

        [Required]
        [Display(Name = "Review Text")]
        public string ReviewText { get; set; }

        [Required]
        [Display(Name = "Review Title")]
        public string ReviewTitle { get; set; }        

        public int VehicleID { get; set; }

        #endregion

        #region CONSTRUCTOR(S)



        #endregion

        #region METHOD(S)



        #endregion
    }
}