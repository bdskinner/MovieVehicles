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

        [HttpGet]
        public ActionResult Index()
        {
            //Get top 5 most recently posted events to display on the index page.
            var topFiveEvents = (from e in db.Events
                                select e).Take(5);

            //Get top 5 most recently posted reviews to display on the index page.
            var topFiveReviews = (from r in db.Reviews
                                 select r).Take(5);
            ViewBag.TopFiveReviews = topFiveReviews.ToList();

            //Dislay the view.
            return View(topFiveEvents.ToList());

            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}