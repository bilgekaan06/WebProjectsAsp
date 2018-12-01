using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginRegistrationDemo.Models;

namespace LoginRegistrationDemo.Controllers
{
    public class RegisterController : Controller
    {
        MVCTutorialEntities db = new MVCTutorialEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index([Bind(Include = "Username,Email,Password")]SiteUser users){
            if (ModelState.IsValid)
            {
                db.SiteUser.Add(users);
                db.SaveChanges();
            }
            ModelState.Clear();
            return View("Index");

        }
    }
}