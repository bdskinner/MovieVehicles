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
using PagedList;
using System.IO;

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
            int pageNumber = (page ?? 1);
            int pageSize = 10;

            IEnumerable<Vehicle> vehicleList = (from v in db.Vehicles
                                       select v);

            //Sort the records.
            switch (sortOrder)
            {
                case "CreatedBy":
                    vehicleList = (from v in vehicleList
                                  orderby v.CreatedBy ascending
                                  select v).ToPagedList(pageNumber, pageSize);    //.ToList();
                    break;
                case "Title":
                    vehicleList = (from v in vehicleList
                                   orderby v.MovieTitle ascending
                                   select v).ToPagedList(pageNumber, pageSize);    //.ToList();
                    break;
                default:
                    //If no sort order is specified sort by the vehicle's name.
                    vehicleList = (from v in vehicleList
                                   orderby v.VehicleName ascending
                                   select v).ToPagedList(pageNumber, pageSize);    //.ToList();
                    break;
            }

            //Return the view.
            return View(vehicleList);
        }

        [HttpPost]
        //public ActionResult Index(string searchTitle, string searchName, int? page)
        public ActionResult Index(string searchTitle, string searchName, string createdBy, int? page)
        {
            //Variable Declarations.
            int pageSize = 50;
            int pageNumber = (page ?? 1);

            IEnumerable<Vehicle> vehicleList = (from v in db.Vehicles
                               select v);


            //If the movie title was passed to the action, search by the title entered.
            if (searchTitle != null)
            {
                vehicleList = (from v in vehicleList
                               where v.MovieTitle.ToUpper().Contains(searchTitle.ToUpper())
                               select v).ToPagedList(pageNumber, pageSize);   
            }

            //If the vehicle name was passed to the action, search by the name entered.
            if (searchName != null)
            {
                vehicleList = (from v in vehicleList
                               where v.VehicleName.ToUpper().Contains(searchName.ToUpper())
                               select v).ToPagedList(pageNumber, pageSize);   
            }

            //If the created by value was passed to the action, search by the person who created the vehicle.
            if (createdBy != null)
            {
                vehicleList = (from v in vehicleList
                               where v.CreatedBy.ToUpper().Contains(createdBy.ToUpper())
                               select v).ToPagedList(pageNumber, pageSize);   
            }

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
        public ActionResult Create([Bind(Include = "VehicleID,CreatedBy,Description,Make,Model,VehiclePhoto,MovieTitle,Status,VehicleName,Year")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                if (vehicle.VehiclePhoto == "" || vehicle.VehiclePhoto == null)
                {
                    vehicle.VehiclePhoto = "imagecomingsoon.jpg";
                }
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




        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }


        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            //Code Found At...
            //Site Name: c-sharpcorner.com
            //URL: https://www.c-sharpcorner.com/article/upload-files-in-asp-net-mvc-5/

            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Photos"), _FileName);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
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
