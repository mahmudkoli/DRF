using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRF.Entities;
using DRF.Services;

namespace DRF.Web.Controllers
{
    public class JsonDataController : Controller
    {
        private ScheduleService _scheduleService;

        public JsonDataController()
        {
            _scheduleService = new ScheduleService();
        }

        public JsonResult GetDoctorAvailableDay(int doctorId, int chamberId)
        {
            var data = _scheduleService.GetDoctorAvailableDay(doctorId, chamberId).ToList();

            var jsonData = new { days = data.Select(x => x.Day) };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDoctorAvailableTime(int doctorId, int chamberId, string date)
        {
            //--------Saturday = 1--------------
            var day = ((int)Convert.ToDateTime(date).DayOfWeek + 1) % 7 + 1;
            var data = _scheduleService.GetDoctorAvailableTime(doctorId, chamberId, day).ToList();

            var jsonData = new { times = data.Select(x =>
            {
                var time = x.StartTime.ToString("t") + "-" + x.EndTime.ToString("t");
                return time.ToString();
            })};
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}