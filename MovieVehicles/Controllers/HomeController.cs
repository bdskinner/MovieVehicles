using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieVehicles.Models;
using MovieVehicles.CustomAttributes;

namespace MovieVehicles.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        #region ACTION(S)

        [HttpGet]
        public ActionResult Index()
        {
            //Variable Declarations.
            //Get top 5 most recently posted events to display on the index page.
            var topFiveEvents = (from e in db.Events
                                 orderby e.EventID descending
                                select e).Take(5);

            //Get top 5 most recently posted reviews to display on the index page.
            var topFiveReviews = (from r in db.Reviews
                                  orderby r.ReviewID descending
                                  select r).Take(5);

            //Add the Top 5 reviews to the ViewBag.
            ViewBag.TopFiveReviews = topFiveReviews.ToList();

            //Get the photo names and file names.
            var photoList2 = (from p in db.Vehicles
                              where p.VehiclePhoto != "imagecomingsoon.jpg"
                              select new { p.VehiclePhoto, p.VehicleName }).ToList();

            //Create a list to store the vehicle names and the file names for the photos.
            List<VehiclePhoto> vehiclePhotoList = new List<VehiclePhoto>();

            //Add the vehicle names and photo file names to the list.
            foreach (var photo in photoList2)
            {
                VehiclePhoto newVehiclePhoto = new VehiclePhoto(photo.VehiclePhoto, photo.VehicleName);
                vehiclePhotoList.Add(newVehiclePhoto);
            }

            //Store the list in the ViewBag to send to the Home Index page.
            ViewBag.SlideShowPhotos = vehiclePhotoList;
            
            //Dislay the view.
            return View(topFiveEvents.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AuthorizationOrRedirect(Roles = "Site Administrator")]
        public ActionResult Admin()
        {
            return View("ApplicationAdministration");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #endregion

        #region PRIVATE METHOD(S)



        #endregion
    }
}