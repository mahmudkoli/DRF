using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities.Base;

namespace DRF.Entities
{
    public class Schedule : Entity
    {
        [Required]
        public int Day { get; set; }
        [Required]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
        [Required]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
        [Required]
        [Display(Name = "Duration Time")]
        public int DurationTime { get; set; }
        [Required]
        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }   
        public virtual Doctor Doctor { get; set; }
        [Required]
        [Display(Name = "Chamber")]
        public int ChamberId { get; set; }
        public virtual Chamber Chamber { get; set; }
    }
}
