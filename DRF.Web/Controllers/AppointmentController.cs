using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRF.Web.Areas.Doctor.Models;

namespace DRF.Web.Controllers
{
    public class AppointmentController : Controller
    {
        private AppointmentModel _appointmentModel;

        public AppointmentController()
        {
            _appointmentModel = new AppointmentModel();
        }

        // GET: Appointment
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetAppoinment(AppointmentDraft draft)
        {
            var newDraft = draft;
            return View();
        }
    }
}