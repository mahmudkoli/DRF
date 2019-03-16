using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRF.Entities;
using DRF.Web.Models;
using PagedList;

namespace DRF.Web.Controllers
{
    [Authorize(Roles = "Patient")]
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

        [HttpGet]
        public ActionResult GetAppointment(AppointmentModel model)
        {
            model.DoctorName = model.GetDoctorName(model.DoctorId);
            model.ChamberName = model.GetChamberName(model.ChamberId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmAppointment(AppointmentModel model)
        {
            if (ModelState.IsValid)
            {
                var isSaved = model.Add();
                if (isSaved)
                {
                    return View();
                }
            }

            return RedirectToAction("GetAppointment", model);
        }

        public ActionResult RecentAppointment()
        {
            var appoinment = _appointmentModel.GetRecentConfirmAppointmentInfo();
            return View(appoinment);
        }

        public ActionResult AppointmentHistory(AppointmentSearchModel model)
        {
            model = model ?? new AppointmentSearchModel();
            var appointments = _appointmentModel.GetAllByPatientId(model.AppointmentStatus, model.LastDays).ToList();
            model.AppointmentCollection = appointments.ToPagedList(model.Page, model.PageSize);
            return View(model);
        }
    }
}