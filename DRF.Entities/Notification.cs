using DRF.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DRF.Entities
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public int NotificationObjectId { get; set; }
        public virtual NotificationObject NotificationObject { get; set; }
        public int NotifierId { get; set; }
        public virtual User Notifier { get; set; }
        public bool IsActive { get; set; }
        public bool IsRead { get; set; }
        public bool IsReminder { get; set; }

        public Notification()
        {
            this.IsActive = true;
            this.IsRead = false;
            this.IsReminder = true;
        }
        public Notification(int NotificationObjectId, int NotifierId) : this()
        {
            this.NotificationObjectId = NotificationObjectId;
            this.NotifierId = NotifierId;
        }
    }
}
