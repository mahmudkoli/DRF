using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRF.Common;
using DRF.Entities;
using DRF.Services;

namespace DRF.Web.Areas.Doctor.Models
{
    public class AppointmentModel
    {
        private AppointmentService _appointmentService;
        public AppointmentModel()
        {
            _appointmentService = new AppointmentService();
        }

        public IEnumerable<Appointment> GetAllByDoctorId()
        {
            return _appointmentService.GetAllByDoctorId(AuthenticatedDoctorUserModel.GetDoctorUserFromIdentity().Id);
        }

        public bool ApprovedAppointmentById(int id)
        {
            return _appointmentService.ApprovedAppointmentById(id);
        }

        public bool RejectedAppointmentById(int id)
        {
            return _appointmentService.RejectedAppointmentById(id);
        }

        public IEnumerable<Appointment> GetAllPendingAppointmentByDoctorId()
        {
            return _appointmentService.GetAllByDoctorIdWithStatus(
                AuthenticatedDoctorUserModel.GetDoctorUserFromIdentity().Id, (int)CustomEnum.AppointmentStatus.Requested);
        }
    }
}