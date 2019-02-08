using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities.Base;

namespace DRF.Entities
{
    public class Schedule : Entity
    {
        public int Day { get; set; }
        public DateTime StartTime { get; set; } 
        public DateTime EndTime { get; set; }
        public int DurationTime { get; set; }
        public int DoctorId { get; set; }   
        public virtual Doctor Doctor { get; set; }
        public int? ChamberId { get; set; }
        public virtual Chamber Chamber { get; set; }
    }
}
