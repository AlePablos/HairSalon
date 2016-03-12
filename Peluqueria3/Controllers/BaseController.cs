using Peluqueria3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Peluqueria3.Controllers
{
    public class BaseController : Controller
    {
        protected HairSalonDBContext db = new HairSalonDBContext();
        protected User currentUser = null;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.currentUser = Session["currentUser"] as User;
            ViewBag.currentUser = this.currentUser;
        }
    }
}