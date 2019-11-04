using DRF.Services;
using DRF.Web.Models.NotificationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DRF.Web.Controllers
{
    public class NotificationController : Controller
    {
        private readonly NotificationModel _notificationModel;

        public NotificationController()
        {
            _notificationModel = new NotificationModel();
        }

        public ActionResult GoToDetails(int notificationId, int entityTypeId, int entityId, bool isActor = false)
        {
            _notificationModel.SeeDetailsNotification(notificationId);
            return RedirectToAction("PendingAppointment", "Appointment", new { Area = "Doctor" });
        }
        //public ActionResult ShowNotifications(int notifierId)
        //{
        //    return RedirectToAction("", "", new { Area = "" });
        //}
    }
}