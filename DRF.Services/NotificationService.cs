using DRF.Common;
using DRF.Entities;
using DRF.Repository;
using DRF.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRF.Services
{
    public class NotificationService
    {
        private NotificationUnitOfWork _notificationUnitOfWork;

        public NotificationService()
        {
            _notificationUnitOfWork = new NotificationUnitOfWork(new DRFDbContext());
        }

        //public IEnumerable<Notification> GetAll()
        //{
        //    return _notificationUnitOfWork.NotificationRepository.GetAll();
        //}
        //public IEnumerable<Notification> GetAll(string name, byte? status)
        //{
        //    var data = _notificationUnitOfWork.NotificationRepository.Get(x => true);
        //    //data = string.IsNullOrEmpty(name) ? data : data.Where(x => x.Name.ToLower().Contains(name.ToLower()));
        //    data = status == null ? data : data.Where(x => x.Status == status);
        //    return data.OrderByDescending(x => (x.UpdatedAt == null ? x.CreatedAt : x.UpdatedAt));
        //}

        //public bool ChangeStatus(int id)
        //{
        //    var city = _notificationUnitOfWork.NotificationRepository.GetById(id);
        //    city.Status = city.Status == (byte)CustomEnum.Status.Active ?
        //        (byte)CustomEnum.Status.Inactive : (byte)CustomEnum.Status.Active;
        //    city.UpdatedAt = DateTime.Now;
        //    return _notificationUnitOfWork.Save();
        //}

        //public int ActiveCount()
        //{
        //    return _notificationUnitOfWork.NotificationRepository.ActiveCount();
        //}

        public Notification Add(int entityTypeId, int entityId, int actorId, int notifierId)
        {
            var notificationObject = new NotificationObject(entityTypeId, entityId);
            _notificationUnitOfWork.NotificationRepository.AddNotificationObject(notificationObject);
            _notificationUnitOfWork.Save();

            var notificationChange = new NotificationChange(notificationObject.Id, actorId);
            _notificationUnitOfWork.NotificationRepository.AddNotificationChange(notificationChange);

            var notification = new Notification(notificationObject.Id, notifierId);
            _notificationUnitOfWork.NotificationRepository.AddNotification(notification);

            _notificationUnitOfWork.Save();

            return _notificationUnitOfWork.NotificationRepository.GetByNotificationId(notification.Id);
        }

        public IEnumerable<Notification> GetAllByNotifierId(int notifierId)
        {
            return _notificationUnitOfWork.NotificationRepository.GetAllByNotifierId(notifierId);
        }

        public IEnumerable<Notification> GetAllReminderByNotifierId(int notifierId)
        {
            return _notificationUnitOfWork.NotificationRepository.GetAllReminderByNotifierId(notifierId);
        }

        public IEnumerable<Notification> GetAllNotifyByNotifierId(int notifierId)
        {
            return _notificationUnitOfWork.NotificationRepository.GetAllNotifyByNotifierId(notifierId);
        }
    }
}
