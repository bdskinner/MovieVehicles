using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieVehicles.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Net;
using System.Data.Entity;

namespace MovieVehicles.Controllers
{
    public class IdentityRoleController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: IdentityRole
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create([Bind(Include = "ID,Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(role);
        }

        [HttpGet]
        public ActionResult Delete(string ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IdentityRole role = db.Roles.Find(ID);

            if (role == null)
            {
                return new HttpNotFoundResult();
            }

            return View(role);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(string ID)
        {
            IdentityRole identityRoleTemp = db.Roles.Find(ID);
            db.Roles.Remove(identityRoleTemp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(string ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IdentityRole role = db.Roles.Find(ID);

            if (role == null)
            {
                return new HttpNotFoundResult();
            }

            return View(role);
        }

        [HttpGet]
        public ActionResult Edit(string ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IdentityRole role = db.Roles.Find(ID);

            if (role == null)
            {
                return HttpNotFound();
            }

            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(role);
        }
    }
}