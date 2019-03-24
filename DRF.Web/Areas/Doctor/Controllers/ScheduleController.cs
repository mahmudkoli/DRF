using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRF.Common;
using DRF.Web.Areas.Doctor.Models;
using PagedList;

namespace DRF.Web.Areas.Doctor.Controllers
{
    [Authorize(Roles = "Doctor")]
    [RedirectingAction]
    public class ScheduleController : Controller
    {
        private ScheduleModel _scheduleModel;

        public ScheduleController()
        {
            _scheduleModel = new ScheduleModel();
        }

        // GET: Doctor/Schedule
        public ActionResult Index(ScheduleSearchModel model)
        {
            model = model ?? new ScheduleSearchModel();
            var schedules = _scheduleModel.GetAllSchedules(model.Chamber, model.Day).ToList();
            model.ScheduleCollection = schedules.ToPagedList(model.Page, model.PageSize);
            model.ChamberCollection = _scheduleModel.GetAllChamberByDoctorId();
            return View(model);
        }

        public ActionResult Create()
        {
            return View(_scheduleModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ScheduleModel model)
        {
            if (ModelState.IsValid)
            {
                var isSaved = model.Add();
                if (isSaved)
                {
                    TempData[CustomMessage.Success] = "Schedule successfully created";
                    return RedirectToAction("Index");
                }
            }

            TempData[CustomMessage.Failure] = "Schedule create failed";
            return View(model);
        }
        
        public ActionResult Delete(int id)
        {
            var isDeleted = _scheduleModel.Delete(id);
            return Json(new { data = isDeleted }, JsonRequestBehavior.AllowGet);
        }
    }
}