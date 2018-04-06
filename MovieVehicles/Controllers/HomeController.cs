using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieVehicles.Models;

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
                                select e).Take(5);

            //Get top 5 most recently posted reviews to display on the index page.
            var topFiveReviews = (from r in db.Reviews
                                 select r).Take(5);

            //Add the Top 5 reviews to the ViewBag.
            ViewBag.TopFiveReviews = topFiveReviews.ToList();

            //Get the photo names and file paths.
            var photoList = (from p in db.Vehicles
                             where p.VehiclePhoto != "imagecomingsoon.jpg"
                             select p.VehiclePhoto).ToList();

            //Add the photo paths for the slideshow to the ViewBag.
            ViewBag.SlideShowPhotos = photoList.ToList();

            //Dislay the view.
            return View(topFiveEvents.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

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