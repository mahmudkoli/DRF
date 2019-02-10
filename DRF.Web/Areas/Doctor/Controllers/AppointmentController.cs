using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DRF.Web.Areas.Doctor.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: Doctor/Appointment
        public ActionResult Index()
        {
            return View();
        }
    }
}