using DRF.Common;
using DRF.Services;
using DRF.Web.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DRF.Web.Models.NotificationModels
{
    public class NotificationModel
    {
        private NotificationService _notificationService;
        private NotificationHub _notificationHub;

        public string UserId { get; set; }

        public NotificationModel()
        {
            _notificationService = new NotificationService();
            _notificationHub = new NotificationHub();
        }

        public void SendNotification(int entityTypeId, int entityId, int actorId, int notifierId)
        {
            var notification = _notificationService.Add(entityTypeId, entityId, actorId, notifierId);
            _notificationHub.SendNotification(notifierId);
        }

        //public IEnumerable<GlobalNotification> GetAllGlobalNotifyByNotifierId(int notifierId)
        //{
        //    return _notificationService.GetAllNotificationByNotifierId(notifierId);
        //}
    }
}