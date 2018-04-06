using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieVehicles.Models
{
    public class Vehicle
    {
        #region FIELD(S)

        [Required]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Required]
        public string Description { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        [Required]
        [Display(Name = "Vehicle Photo Path")]
        public string VehiclePhoto { get; set; }

        [Required]
        [Display(Name = "Seen In Movie")]
        public string MovieTitle { get; set; }

        [Required]
        [Display(Name = "Vehicle Status")]
        public string Status { get; set; }

        [Required]
        [Display(Name = "Vehicle Name")]
        public int VehicleID { get; set; }

        [Required]
        [Display(Name = "Vehicle Name")]
        public string VehicleName { get; set; }

        public int Year { get; set; }

        #endregion

        #region CONSTRUCTOR(S)



        #endregion

        #region METHOD(S)



        #endregion
    }
}