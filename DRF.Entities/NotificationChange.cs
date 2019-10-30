using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRF.Entities
{
    public class NotificationChange
    {
        [Key]
        public int Id { get; set; }
        public int NotificationObjectId { get; set; }
        public virtual NotificationObject NotificationObject { get; set; }
        public int ActorId { get; set; }
        public virtual User Actor { get; set; }
        public bool IsActive { get; set; }

        public NotificationChange()
        {
            this.IsActive = true;
        }
        public NotificationChange(int NotificationObjectId, int ActorId) : this()
        {
            this.NotificationObjectId = NotificationObjectId;
            this.ActorId = ActorId;
        }
    }
}
