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
            List<ReviewVM> ReviewVMlist = new List<ReviewVM>(); // to hold list of reviews

            ReviewVMlist = BuildVehicleViewModelList();

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
            List<ReviewVM> ReviewVMlist = new List<ReviewVM>();
            //IEnumerable<Review> reviews;
            //IEnumerable<Movie> movieResults = null;
            //int pageSize = 50;
            //int pageNumber = (page ?? 1);
            
            //Get the information for the reviews as well as the vehicle name the review is for from the database.
            var reviewlist = (from r in db.Reviews
                              join v in db.Vehicles on r.VehicleID equals v.VehicleID
                              select new { r.ReviewID, r.ReviewTitle, r.ReviewDate, v.VehicleName }).ToList();

            //Store the reviews data in reviewlist.
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



            ReviewVM vehicleReviewModel = BuildVehicleViewModel(review);



            if (review == null)
            {
                return HttpNotFound();
            }
            //return View(review);
            return View(vehicleReviewModel);
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            //Build a list of vehicle ID and name values.
            var vehicleList = (from v in db.Vehicles
                               select v).ToList();

            ViewBag.SelectVehicleList = new SelectList(vehicleList, "VehicleID", "VehicleName");
            
            //Return the view.
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
            //Build a list of vehicle ID and name values.
            var vehicleList = (from v in db.Vehicles
                               select v).ToList();

            ViewBag.SelectVehicleList = new SelectList(vehicleList, "VehicleID", "VehicleName");

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



            ReviewVM vehicleReviewModel = BuildVehicleViewModel(review);



            if (review == null)
            {
                return HttpNotFound();
            }
            //return View(review);
            return View(vehicleReviewModel);
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

        public ActionResult ListOfReviewsByVehicle(int ID)
        {
            //Get a list of reviews associated with the vehicle who's id was passed in the ID parameter.
            var reviewList = (from v in db.Reviews
                              where v.VehicleID == ID
                              select v).ToList();

            //Get the vehicle information.
            var vehicle = (from v in db.Vehicles
                          where v.VehicleID == ID
                          select v).SingleOrDefault();
            ViewBag.Vehicle = vehicle;

            //Check to see if any vehicle information was found.
            if (vehicle != null)
            {
                //If the information was found...

                return View(reviewList);
            }
            else
            {
                //If no information was found...

                ViewBag.ErrorMessage = "Vehicle Not Found!!";
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult UserCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserCreate([Bind(Include = "ReviewID,FirstName,LastName,ReviewDate,ReviewText,ReviewTitle,VehicleID")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("ListOfReviewsByVehicle", new { id = review.VehicleID });
            }

            return View(review);
        }



        private ReviewVM BuildVehicleViewModel(Review review)
        {
            //Get the vehicle name for the review provided.
            var vehicleName = from v in db.Vehicles
                              where v.VehicleID == review.VehicleID
                              select v.VehicleName;

            //Return the vehicle name with the review information in a new view model.
            return new ReviewVM()
            {
                ReviewID = review.ReviewID,
                ReviewTitle = review.ReviewTitle,
                ReviewDate = review.ReviewDate,
                FirstName = review.FirstName,
                LastName = review.LastName,
                ReviewText = review.ReviewText,
                VehicleName = vehicleName.SingleOrDefault()
            };
        }

        private List<ReviewVM> BuildVehicleViewModelList()
        {
            //Variable Declarations.
            List<ReviewVM> ReviewVMlist = new List<ReviewVM>();

            //Get the information for the reviews as well as the vehicle name the review is for from the database.
            var reviewlist = (from r in db.Reviews
                              join v in db.Vehicles on r.VehicleID equals v.VehicleID
                              select new { r.ReviewID, r.ReviewTitle, r.ReviewDate, v.VehicleName }).ToList();

            //Store the reviews data in reviewlist.
            foreach (var item in reviewlist)
            {
                ReviewVM rvm = new ReviewVM(); // ViewModel
                rvm.ReviewID = item.ReviewID;
                rvm.ReviewTitle = item.ReviewTitle;
                rvm.ReviewDate = item.ReviewDate;
                rvm.VehicleName = item.VehicleName;
                ReviewVMlist.Add(rvm);
            }

            //Return the list of Review View Models.
            return ReviewVMlist;
        }
    }
}
