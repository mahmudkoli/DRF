using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRF.Entities;
using DRF.Web.Areas.Doctor.Models;
using PagedList;

namespace DRF.Web.Areas.Doctor.Controllers
{
    [Authorize(Roles = "Doctor")]
    [RedirectingAction]
    public class AppointmentController : Controller
    {
        private AppointmentSearchModel _appointmentSearchModel;
        private AppointmentModel _appointmentModel;

        public AppointmentController()
        {
            _appointmentSearchModel = new AppointmentSearchModel();
            _appointmentModel = new AppointmentModel();
        }

        public ActionResult AppointmentHistory(AppointmentSearchModel model)
        {
            model = model ?? new AppointmentSearchModel();
            var appoinments = _appointmentModel.GetAllByDoctorId(model.AppointmentStatus, model.LastDays).ToList();
            model.AppointmentCollection = appoinments.ToPagedList(model.Page, model.PageSize);
            return View(model);
        }

        public ActionResult PendingAppointment(AppointmentSearchModel model)
        {
            model = model ?? new AppointmentSearchModel();
            var appoinments = _appointmentModel.GetAllPendingAppointmentByDoctorId(model.LastDays).ToList();
            model.AppointmentCollection = appoinments.ToPagedList(model.Page, model.PageSize);
            return View(model);
        }

        public ActionResult ApprovedAppointment(int id)
        {
            var isUpdated = _appointmentModel.ApprovedAppointmentById(id);
            return RedirectToAction("PendingAppointment");
        }

        public ActionResult RejectedAppointment(int id)
        {
            var isUpdated = _appointmentModel.RejectedAppointmentById(id);
            return RedirectToAction("PendingAppointment");
        }
    }
}