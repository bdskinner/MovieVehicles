﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieVehicles.Models;
using MovieVehicles.CustomAttributes;
using MovieVehicles.Enums;

namespace MovieVehicles.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Index(string sortOrder)
        {
            //Get a list of states.
            var StateAbbr = Enum.GetValues(typeof(Enums.Enumerations.States)).OfType<Enums.Enumerations.States>().ToList();
            ViewBag.States = StateAbbr.ToList();

            //Get a list of the events.
            var eventList = (from v in db.Events
                               select v).ToList();

            //Sort the records.
            switch (sortOrder)
            {
                case "Date":
                    eventList = (from v in eventList
                                   orderby v.EventDate ascending
                                   select v).ToList();
                    break;
                case "City":
                    eventList = (from v in eventList
                                   orderby v.EventCity ascending
                                   select v).ToList();
                    break;
                case "State":
                    eventList = (from v in eventList
                                 orderby v.EventState ascending
                                 select v).ToList();
                    break;
                default:
                    //If no sort order is specified sort by the event title.
                    eventList = (from v in eventList
                                   orderby v.EventTitle ascending
                                   select v).ToList();
                    break;
            }

            return View(eventList.ToList());




            //return View(db.Events.ToList());
        }

        [HttpPost]
        //public ActionResult Index(string searchTitle, string searchName, int? page)
        public ActionResult Index(string searchTitle, string searchCity, string searchstate)
        {
            //Variable Declarations.
            //IEnumerable<Review> reviews;
            //IEnumerable<Movie> movieResults = null;
            //int pageSize = 50;
            //int pageNumber = (page ?? 1);

            //Get a list of states.
            var StateAbbr = Enum.GetValues(typeof(Enums.Enumerations.States)).OfType<Enums.Enumerations.States>().ToList();
            ViewBag.States = StateAbbr.ToList();

            //Get a list of the events.
            var eventList = (from v in db.Events
                               select v).ToList();


            //If the movie title was passed to the action, search by the title entered.
            if (searchTitle != null)
            {
                eventList = (from v in eventList
                               where v.EventTitle.ToUpper().Contains(searchTitle.ToUpper())
                               select v).ToList();
            }

            //If the vehicle name was passed to the action, search by the title entered.
            if (searchCity != null)
            {
                eventList = (from v in eventList
                               where v.EventCity.ToUpper().Contains(searchCity.ToUpper())
                               select v).ToList();
            }

            //If the Genre was passed to the action, sort by the genre selected.
            if (searchstate != "" || searchstate != "Choose a State" || searchstate == null)
            {
                eventList = (from v in eventList
                               where v.EventState.ToUpper().Contains(searchstate.ToUpper())
                               select v).ToList();
            }

            //Set Paginate settings.
            //movies = movies.ToPagedList(pageNumber, pageSize);

            //Return the view.
            return View(eventList.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        [HttpGet]
        [AuthorizationOrRedirect(Roles = "Site Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,EventDate,EventDescription,EventCity,EventState,EventTitle,VehicleID")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        [AuthorizationOrRedirect(Roles = "Site Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizationOrRedirect(Roles = "Site Administrator")]
        public ActionResult Edit([Bind(Include = "EventID,EventDate,EventDescription,EventCity,EventState,EventTitle,VehicleID")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        [AuthorizationOrRedirect(Roles = "Site Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthorizationOrRedirect(Roles = "Site Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
