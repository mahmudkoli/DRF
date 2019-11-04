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

        //public string UserId { get; set; }
        private int _loggedUserId;

        public NotificationModel()
        {
            _notificationService = new NotificationService();
            _notificationHub = new NotificationHub();
            _loggedUserId = AuthenticatedUserModel.GetUserFromIdentity().Id;
        }

        public void SendNotification(int entityTypeId, int entityId, int actorId, int notifierId)
        {
            var notification = _notificationService.Add(entityTypeId, entityId, actorId, notifierId);
            _notificationHub.SendNotification(notifierId);
        }

        public void SeeDetailsNotification(int notificationId)
        {
            _notificationService.SeeDetailsNotification(notificationId);
            _notificationHub.SendNotification(_loggedUserId);
        }

        //public IEnumerable<GlobalNotification> GetAllGlobalNotifyByNotifierId(int notifierId)
        //{
        //    return _notificationService.GetAllNotificationByNotifierId(notifierId);
        //}
    }
}