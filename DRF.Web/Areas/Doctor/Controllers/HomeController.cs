using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DRF.Web.Areas.Doctor.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class HomeController : Controller
    {
        // GET: Doctor/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}