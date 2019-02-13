using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRF.Common;
using DRF.Web.Areas.Doctor.Models;

namespace DRF.Web.Areas.Doctor.Controllers
{
    public class ScheduleController : Controller
    {
        private ScheduleModel _scheduleModel;

        public ScheduleController()
        {
            _scheduleModel = new ScheduleModel();
        }

        // GET: Doctor/Schedule
        public ActionResult Index()
        {
            _scheduleModel.ScheduleCollection = _scheduleModel.GetAllSchedules();
            return View(_scheduleModel);
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
    }
}