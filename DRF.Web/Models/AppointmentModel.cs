using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRF.Common;
using DRF.Entities;
using DRF.Services;

namespace DRF.Web.Models
{
    public class AppointmentModel
    {
        public int DoctorId { get; set; }
        public int ChamberId { get; set; }
        public int PatientId { get; set; }
        public DateTime NewAppointmentDate { get; set; }
        public DateTime NewAppointmentTime { get; set; }
        public string DoctorName { get; set; }
        public string ChamberName { get; set; }
        public string Disease { get; set; }
        public double AppointmentFees { get; set; }
        public int AppointmentType { get; set; }

        private DoctorService _doctorService;
        private ChamberService _chamberService;
        private AppointmentService _appointmentService;
        public AppointmentModel()
        {
            _doctorService = new DoctorService();
            _chamberService = new ChamberService();
            _appointmentService = new AppointmentService();
        }

        public string GetDoctorName(int id)
        {
            return _doctorService.GetDoctorNameById(id);
        }

        public string GetChamberName(int id)
        {
            return _chamberService.GetChamberNameById(id);
        }

        public bool Add()
        {
            var newAppointment = new Appointment()
            {
                PatientId = AuthenticatedPatientUserModel.GetPatientUserFromIdentity().Id,
                DoctorId = this.DoctorId,
                ChamberId = this.ChamberId,
                AppointmentDate = this.NewAppointmentDate,
                AppointmentTime = this.NewAppointmentTime,
                AppointmentType = this.AppointmentType,
                AppointmentFees = this.AppointmentFees,
                Disease = this.Disease
            };

            return _appointmentService.Add(newAppointment);
        }
    }
}