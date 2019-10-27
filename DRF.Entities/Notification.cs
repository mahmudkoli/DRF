using DRF.Entities.Base;
using System;
using System.Collections.Generic;

namespace DRF.Entities
{
    public partial class Notification : Entity
    {
        public Nullable<int> Type { get; set; }
        public string Details { get; set; }
        public string Title { get; set; }
        public string DetailsURL { get; set; }
        public string SentTo { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public Nullable<bool> IsRead { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsReminder { get; set; }
        public string Code { get; set; }
        public string NotificationType { get; set; }
    }
}
