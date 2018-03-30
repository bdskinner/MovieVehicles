using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieVehicles.Models;
using MovieVehicles.ViewModels;

namespace MovieVehicles.Controllers
{
    public class ReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Index(string sortOrder)
        {
            //ApplicationDbContext orderdb = new ApplicationDbContext(); //dbcontect class

            List<ReviewVM> ReviewVMlist = new List<ReviewVM>(); // to hold list of reviews

            var reviewlist = (from r in db.Reviews
                                join v in db.Vehicles on r.VehicleID equals v.VehicleID
                                select new { r.ReviewID, r.ReviewTitle, r.ReviewDate, v.VehicleName}).ToList();

            //query getting data from database from joining two tables and storing data in customerlist
            foreach (var item in reviewlist)
            {
                ReviewVM rvm = new ReviewVM(); // ViewModel
                rvm.ReviewID = item.ReviewID;
                rvm.ReviewTitle = item.ReviewTitle;
                rvm.ReviewDate = item.ReviewDate;
                rvm.VehicleName = item.VehicleName;
                ReviewVMlist.Add(rvm);
            }

            switch (sortOrder)
            {
                case "Date":
                    ReviewVMlist = (from r in ReviewVMlist
                                  orderby r.ReviewDate ascending
                                  select r).ToList();
                    break;
                case "VehicleName":
                    ReviewVMlist = (from r in ReviewVMlist
                                  orderby r.VehicleName ascending
                                  select r).ToList();
                    break;
                default:
                    ReviewVMlist = (from r in ReviewVMlist
                                    orderby r.ReviewTitle ascending
                                  select r).ToList();
                    break;
            }

            return View((IList<ReviewVM>)ReviewVMlist);


            //return View(db.Reviews.ToList());
        }

        [HttpPost]
        //public ActionResult Index(string searchTitle, string searchName, int? page)
        public ActionResult Index(string searchTitle, string searchName)
        {
            //Variable Declarations.
            //IEnumerable<Review> reviews;
            //IEnumerable<Movie> movieResults = null;
            //int pageSize = 50;
            //int pageNumber = (page ?? 1);

            List<ReviewVM> ReviewVMlist = new List<ReviewVM>(); // to hold list of reviews

            var reviewlist = (from r in db.Reviews
                              join v in db.Vehicles on r.VehicleID equals v.VehicleID
                              select new { r.ReviewID, r.ReviewTitle, r.ReviewDate, v.VehicleName }).ToList();

            //query getting data from database from joining two tables and storing data in customerlist
            foreach (var item in reviewlist)
            {
                ReviewVM rvm = new ReviewVM(); // ViewModel
                rvm.ReviewID = item.ReviewID;
                rvm.ReviewTitle = item.ReviewTitle;
                rvm.ReviewDate = item.ReviewDate;
                rvm.VehicleName = item.VehicleName;
                ReviewVMlist.Add(rvm);
            }

            //If the review title was passed to the action, search by the title entered.
            if (searchTitle != null)
            {
                ReviewVMlist = (from r in ReviewVMlist
                               where r.ReviewTitle.ToUpper().Contains(searchTitle.ToUpper())
                               select r).ToList();
            }

            //If the vehicle name was passed to the action, search by the title entered.
            if (searchTitle != null)
            {
                ReviewVMlist = (from r in ReviewVMlist
                                where r.VehicleName.ToUpper().Contains(searchName.ToUpper())
                                select r).ToList();
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
            return View(ReviewVMlist);
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReviewID,FirstName,LastName,ReviewDate,ReviewText,ReviewTitle,VehicleID")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(review);
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReviewID,FirstName,LastName,ReviewDate,ReviewText,ReviewTitle,VehicleID")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(review);
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
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
