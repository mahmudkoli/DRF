using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
