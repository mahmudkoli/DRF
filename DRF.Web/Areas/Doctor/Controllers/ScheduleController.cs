using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ScheduleModel model)
        {
            return View();
        }
    }
}