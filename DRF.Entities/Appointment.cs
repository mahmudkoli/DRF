using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities.Base;

namespace DRF.Entities
{
    public class Appointment : Entity
    {
        [Required]
        [Display(Name = "Patient")]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        [Required]
        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        [Required]
        [Display(Name = "Chamber")]
        public int ChamberId { get; set; }
        public virtual Chamber Chamber { get; set; }
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public DateTime AppointmentTime { get; set; }
        public int AppointmentStatus { get; set; }
        public string Disease { get; set; }
        public string Reason { get; set; }
        public int AppointmentType { get; set; }
        public double? AppointmentFees { get; set; }
        
    }
}
