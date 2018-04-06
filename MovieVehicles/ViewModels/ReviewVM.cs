using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieVehicles.ViewModels
{
    public class ReviewVM
    {
        public string FirstName { get; set; }   //From Review Model

        public string LastName { get; set; }   //From Review Model

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ReviewDate { get; set; }   //From Review Model

        public int ReviewID { get; set; }   //From Review Model

        public string ReviewText { get; set; }   //From Review Model

        public string ReviewTitle { get; set; }   //From Review Model

        public int VehicleID { get; set; }   //From Review Model

        public string VehicleName { get; set; }   //From Vehicle Model
    }
}