using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRF.Common
{
    public class GlobalNotification
    {
        //public int Id { get; set; }
        //public int NotificationObjectId { get; set; }
        //public virtual NotificationObject NotificationObject { get; set; }
        //public int NotifierId { get; set; }
        //public virtual User Notifier { get; set; }
        //public bool IsActive { get; set; }
        public int NotificationId { get; set; }
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public int NotifierId { get; set; }
        public string NotifierName { get; set; }
        public int EntityTypeId { get; set; }
        public string NotifyMessage { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int EntityId { get; set; }
        public bool IsRead { get; set; }
        public bool IsReminder { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
