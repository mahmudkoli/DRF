using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRF.Entities;

namespace DRF.Web.Areas.Doctor.Models
{
    public class AppointmentModel : Appointment
    {
        public AppointmentModel()
        {
        }
    }

    public class AppointmentDraft
    {
        public int DoctorId { get; set; }
        public int ChamberId { get; set; }
        public int PatientId { get; set; }
        public DateTime NewAppointmentDate { get; set; }
        public DateTime NewAppointmentTime { get; set; }
    }
}