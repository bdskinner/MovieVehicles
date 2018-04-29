using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieVehicles.ViewModels
{
    public class EventVM
    {
        public int EventID { get; set; }

        public string EventTitle { get; set; }

        public string EventDescription { get; set; }

        [DisplayFormat(DataFormatString = "{0:M/d/yyyy}")]
        public DateTime EventDate { get; set; }

        public string EventCity { get; set; }

        public string EventState { get; set; }

        public string VehicleName { get; set; }
    }
}