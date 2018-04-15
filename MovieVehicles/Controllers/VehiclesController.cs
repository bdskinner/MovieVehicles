using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieVehicles.Models;
using MovieVehicles.CustomAttributes;

namespace MovieVehicles.Controllers
{
    public class VehiclesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        //public ActionResult Index()
        public ActionResult Index(string sortOrder, int? page)
        {
            //Variable Declarations.
            //MovieRepository movieRepository = new MovieRepository();
            //IEnumerable<Movie> movies;
            //int pageSize = 50;
            //int pageNumber = (page ?? 1);

            //Get a list of the vehicles.
            var vehicleList = (from v in db.Vehicles
                              select v).ToList();

            //Sort the records.
            switch (sortOrder)
            {
                case "CreatedBy":
                    vehicleList = (from v in vehicleList
                                  orderby v.CreatedBy ascending
                                  select v).ToList();
                    break;
                case "Title":
                    vehicleList = (from v in vehicleList
                                   orderby v.MovieTitle ascending
                                   select v).ToList();
                    break;
                default:
                    //If no sort order is specified sort by the vehicle's name.
                    vehicleList = (from v in vehicleList
                                   orderby v.VehicleName ascending
                                   select v).ToList();
                    break;
            }

            //Set Paginate settings.
            //movies = movies.ToPagedList(pageNumber, pageSize);

            //Return the view.
            return View(vehicleList);



            //return View(db.Vehicles.ToList());
        }

        [HttpPost]
        //public ActionResult Index(string searchTitle, string searchName, int? page)
        public ActionResult Index(string searchTitle, string searchName, string createdBy)
        {
            //Variable Declarations.
            //IEnumerable<Review> reviews;
            //IEnumerable<Movie> movieResults = null;
            //int pageSize = 50;
            //int pageNumber = (page ?? 1);

            var vehicleList = (from v in db.Vehicles
                               select v).ToList();


            //If the movie title was passed to the action, search by the title entered.
            if (searchTitle != null)
            {
                vehicleList = (from v in vehicleList
                               where v.MovieTitle.ToUpper().Contains(searchTitle.ToUpper())
                               select v).ToList();
            }

            //If the vehicle name was passed to the action, search by the title entered.
            if (searchName != null)
            {
                vehicleList = (from v in vehicleList
                               where v.VehicleName.ToUpper().Contains(searchName.ToUpper())
                               select v).ToList();
            }

            //If the created by value was passed to the action, search by the person who created the vehicle.
            if (createdBy != null)
            {
                vehicleList = (from v in vehicleList
                               where v.CreatedBy.ToUpper().Contains(createdBy.ToUpper())
                               select v).ToList();
            }



            //If the Genre was passed to the action, sort by the genre selected.
            //if (genreFilter != "" || genreFilter == null)
            //{
            //    movies = from m in movies
            //             where m.GenreTitle == genreFilter
            //             select m;
            //}

            //Set Paginate settings.
            //movies = movies.ToPagedList(pageNumber, pageSize);

            //Return the view.
            return View(vehicleList);
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        [AuthorizationOrRedirect(Roles = "Site Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleID,CreatedBy,Description,Make,Model,MoviePoster,MovieTitle,Status,VehicleName,Year")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        [AuthorizationOrRedirect(Roles = "Site Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizationOrRedirect(Roles = "Site Administrator")]
        public ActionResult Edit([Bind(Include = "VehicleID,CreatedBy,Description,Make,Model,VehiclePhoto,MovieTitle,Status,VehicleName,Year")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        [AuthorizationOrRedirect(Roles = "Site Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizationOrRedirect(Roles = "Site Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
