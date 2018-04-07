using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieVehicles.Models
{
    public class Event
    {
        #region FIELD(S)      

        [Required]
        [Display(Name = "Event Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime EventDate { get; set; }

        [Required]
        [Display(Name = "Event Description")]
        public string EventDescription { get; set; }

        public int EventID { get; set; }

        [Required]
        [Display(Name = "Event City")]
        public string EventCity { get; set; }

        [Required]
        [Display(Name = "Event State")]
        public string EventState { get; set; }

        [Required]
        [Display(Name = "Event Title")]
        public string EventTitle { get; set; }

        public int VehicleID { get; set; }

        #endregion

        #region CONSTRUCTOR(S)



        #endregion

        #region METHOD(S)



        #endregion
    }
}