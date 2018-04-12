using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieVehicles.Models
{
    public class VehiclePhoto
    {
        #region FIELD(S)             

        public string PhotoPath { get; set; }

        public string VehicleName { get; set; }

        #endregion

        #region CONSTRUCTOR(S)

        public VehiclePhoto(string photoPath, string vehicleName)
        {
            PhotoPath = photoPath;
            VehicleName = vehicleName;
        }

        #endregion

        #region METHOD(S)



        #endregion
    }
}