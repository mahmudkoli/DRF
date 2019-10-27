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

        public IEnumerable<Notification> GetAll()
        {
            return _notificationUnitOfWork.NotificationRepository.GetAll();
        }
        public IEnumerable<Notification> GetAll(string name, byte? status)
        {
            var data = _notificationUnitOfWork.NotificationRepository.Get(x => true);
            //data = string.IsNullOrEmpty(name) ? data : data.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            data = status == null ? data : data.Where(x => x.Status == status);
            return data.OrderByDescending(x => (x.UpdatedAt == null ? x.CreatedAt : x.UpdatedAt));
        }

        public bool ChangeStatus(int id)
        {
            var city = _notificationUnitOfWork.NotificationRepository.GetById(id);
            city.Status = city.Status == (byte)CustomEnum.Status.Active ?
                (byte)CustomEnum.Status.Inactive : (byte)CustomEnum.Status.Active;
            city.UpdatedAt = DateTime.Now;
            return _notificationUnitOfWork.Save();
        }

        public int ActiveCount()
        {
            return _notificationUnitOfWork.NotificationRepository.ActiveCount();
        }

        public bool AddOrUpdate(Notification notify)
        {
            if (notify.Id == 0)
            {
                var newNotification = new Notification()
                {
                    //Name = city.Name,
                    SentTo = notify.SentTo,
                    Status = (byte)CustomEnum.Status.Active,
                    CreatedAt = DateTime.Now
                };
                _notificationUnitOfWork.NotificationRepository.Add(newNotification);
            }
            else
            {
                var existCity = _notificationUnitOfWork.NotificationRepository.GetById(notify.Id);
                //existCity.Name = city.Name;
                existCity.UpdatedAt = DateTime.Now;
                _notificationUnitOfWork.NotificationRepository.Update(existCity);
            }

            return _notificationUnitOfWork.Save();
        }
    }
}
