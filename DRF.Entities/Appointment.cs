using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities.Base;

namespace DRF.Entities
{
    public class Appointment : Entity
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int ChamberId { get; set; }
        public Chamber Chamber { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime AppointmentTime { get; set; }
        public int AppointmentStatus { get; set; }
        public string Disease { get; set; }
        public string Reason { get; set; }
        public int? AppointmentType { get; set; }
        public double? AppointmentFees { get; set; }
        
    }
}
