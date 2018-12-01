using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LoginRegistrationDemo.Models;

namespace LoginRegistrationDemo.Controllers
{
    public class SiteUsersController : Controller
    {
        private MVCTutorialEntities db = new MVCTutorialEntities();

        // GET: SiteUsers
        public ActionResult Index()
        {
            return View(db.SiteUser.ToList());
        }

        // GET: SiteUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteUser siteUser = db.SiteUser.Find(id);
            if (siteUser == null)
            {
                return HttpNotFound();
            }
            return View(siteUser);
        }

        // GET: SiteUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SiteUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Username,Email,Password,IsValid")] SiteUser siteUser)
        {
            if (ModelState.IsValid)
            {
                db.SiteUser.Add(siteUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(siteUser);
        }

        // GET: SiteUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteUser siteUser = db.SiteUser.Find(id);
            if (siteUser == null)
            {
                return HttpNotFound();
            }
            return View(siteUser);
        }

        // POST: SiteUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Username,Email,Password,IsValid")] SiteUser siteUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siteUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(siteUser);
        }

        // GET: SiteUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SiteUser siteUser = db.SiteUser.Find(id);
            if (siteUser == null)
            {
                return HttpNotFound();
            }
            return View(siteUser);
        }

        // POST: SiteUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SiteUser siteUser = db.SiteUser.Find(id);
            db.SiteUser.Remove(siteUser);
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
