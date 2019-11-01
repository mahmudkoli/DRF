using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Common;
using DRF.Entities;
using DRF.Repository.Base;
using DRF.Repository.Context;

namespace DRF.Repository
{
    public class NotificationRepository
    {
        private DRFDbContext _context;

        public NotificationRepository(DRFDbContext context)
        {
            _context = context;
        }

        public void AddNotificationObject(NotificationObject entity)
        {
            _context.NotificationObjects.Add(entity);
        }

        public void AddNotificationChange(NotificationChange entity)
        {
            _context.NotificationChanges.Add(entity);
        }

        public void AddNotification(Notification entity)
        {
            _context.Notifications.Add(entity);
        }

        public void AddNotificationRange(IEnumerable<Notification> entities)
        {
            _context.Notifications.AddRange(entities);
        }

        public Notification GetByNotificationId(int id)
        {
            return _context.Notifications.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Notification> GetAllByNotifierId(int notifierId)
        {
            return _context.Notifications.Where(x => x.IsActive && x.NotifierId == notifierId);
        }

        public IEnumerable<Notification> GetAllReminderByNotifierId(int notifierId)
        {
            return _context.Notifications.Where(x => x.IsActive && x.NotifierId == notifierId && x.IsReminder);
        }

        public IEnumerable<Notification> GetAllNotifyByNotifierId(int notifierId)
        {
            return _context.Notifications.Where(x => x.IsActive && x.NotifierId == notifierId && !x.IsRead);
        }

        public IEnumerable<GlobalNotification> GetAllGlobalNotifyByNotifierId(int notifierId)
        {
            var notifications = _context.Notifications
                .Join(_context.NotificationObjects,
                    notify => notify.NotificationObjectId,
                    notifyObj => notifyObj.Id,
                    (notify, notifyObj) => new { notify, notifyObj })
                .Join(_context.NotificationChanges,
                    newObj => newObj.notifyObj.Id,
                    notifyChange => notifyChange.NotificationObjectId,
                    (newObj, notifyChange) => new { newObj, notifyChange })
                .Where(a => a.newObj.notify.IsActive && a.newObj.notify.NotifierId == notifierId).Select(x => new GlobalNotification()
                { 
                    ActorId = x.notifyChange.ActorId,
                    ActorName = x.notifyChange.Actor.Name,
                    NotifierId = x.newObj.notify.NotifierId,
                    NotifierName = x.newObj.notify.Notifier.Name,
                    EntityTypeId = x.newObj.notifyObj.EntityTypeId,
                    NotifyMessage = "",
                    Controller = "",
                    Action = "",
                    EntityId = x.newObj.notifyObj.EntityId,
                    IsRead = x.newObj.notify.IsRead,
                    IsReminder = x.newObj.notify.IsReminder,
                    CreatedOn = x.newObj.notifyObj.CreatedOn,

                }).OrderByDescending(o => o.CreatedOn).ToList();

            return notifications;
        }
    }
}
