using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieVehicles.ViewModels
{
    public class ReviewVM
    {
        [Display(Name = "Reviewer Name")]
        public string FirstName { get; set; }   //From Review Model

        [Display(Name = "Last Name")]
        public string LastName { get; set; }   //From Review Model

        [Display(Name = "Review Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ReviewDate { get; set; }   //From Review Model

        public int ReviewID { get; set; }   //From Review Model

        [Display(Name = "Review Text")]
        public string ReviewText { get; set; }   //From Review Model

        [Display(Name = "Review Title")]
        public string ReviewTitle { get; set; }   //From Review Model

        [Display(Name = "Vehicle Name")]
        public int VehicleID { get; set; }   //From Review Model

        [Display(Name = "Vehicle Name")]
        public string VehicleName { get; set; }   //From Vehicle Model
    }
}