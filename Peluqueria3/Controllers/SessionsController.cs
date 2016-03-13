using Peluqueria3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peluqueria3.Controllers
{
    public class SessionsController : BaseController
    {
        // GET: Sessions/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "email,password")] UserSession credentials)
        {
            var user = (from u in db.Users where u.email == credentials.email && u.password == credentials.password select u).FirstOrDefault();

            if(user != null)
            {
                Session["currentUser"] = user;
            }

            user.lastLogged = DateTime.Now;
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        // GET: Sessions/Delete
        public ActionResult Delete()
        {
            Session["currentUser"] = null;
            return RedirectToAction("Index", "Home");
        }
    }

    public class UserSession
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}