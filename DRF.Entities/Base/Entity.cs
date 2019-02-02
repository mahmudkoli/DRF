using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRF.Entities.Base
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte Status { get; set; }

        public Entity()
        {
            CreatedAt = DateTime.Now;
            Status = 1;
        }
    }
}
