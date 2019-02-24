using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRF.Common;
using DRF.Services;

namespace DRF.Web.Areas.Doctor.Models
{
    public class DoctorNotificationModel
    {
        private AppointmentService _appointmentService;

        public DoctorNotificationModel()
        {
            _appointmentService = new AppointmentService();
        }

        public int GetAppointmentRequestPendingCount
        {
            get { return _appointmentService.GetAllByDoctorId(AuthenticatedDoctorUserModel.GetDoctorUserFromIdentity().Id, 
                (int)CustomEnum.AppointmentStatus.Requested, null).Count(); }
        }

        //public static string GetLastAppointmentRequestPatientName
        //{
        //    get { return _appointmentService.GetLastAppointmentRequestPatientByDoctorId(
        //        AuthenticatedDoctorUserModel.GetDoctorUserFromIdentity().Id).User.Name; }
        //}
    }
}