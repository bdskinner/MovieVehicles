using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieVehicles.ViewModels
{
    public class ReviewVM
    {
        public DateTime ReviewDate { get; set; }   //From Review Model

        public int ReviewID { get; set; }   //From Review Model

        public string ReviewTitle { get; set; }   //From Review Model

        public int VehicleID { get; set; }   //From Review Model

        public string VehicleName { get; set; }   //From Vehicle 
    }
}