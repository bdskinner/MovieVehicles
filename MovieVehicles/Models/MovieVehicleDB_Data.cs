using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MovieVehicles.Models
{
    public class MovieVehicleDB_Data : DbContext
    {
        #region FIELD(S)             

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Event> Events { get; set; }

        #endregion

        #region CONSTRUCTOR(S)

        public MovieVehicleDB_Data() : base("MovieVehiclesDB_Remote")
        {

        }

        #endregion

        #region METHOD(S)



        #endregion        
    }
}