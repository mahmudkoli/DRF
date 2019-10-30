using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRF.Entities
{
    public class NotificationObject
    {
        [Key]
        public int Id { get; set; }
        public int EntityTypeId { get; set; }
        public int EntityId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }

        //public string Title { get; set; }
        //public string Details { get; set; }
        //public string DetailsURL { get; set; }

        public NotificationObject()
        {
            this.IsActive = true;
            this.CreatedOn = DateTime.Now;
        }
        public NotificationObject(int EntityTypeId, int EntityId) : this()
        {
            this.EntityTypeId = EntityTypeId;
            this.EntityId = EntityId;
        }
    }
}
