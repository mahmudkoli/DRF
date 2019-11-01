using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DRF.Web.Controllers
{
    public class NotificationController : Controller
    {
        public ActionResult GoToDetails(int entityTypeId, int entityId, bool isActor = false)
        {
            return RedirectToAction("PendingAppointment", "Appointment", new { Area = "Doctor" });
        }
        //public ActionResult ShowNotifications(int notifierId)
        //{
        //    return RedirectToAction("", "", new { Area = "" });
        //}
    }
}