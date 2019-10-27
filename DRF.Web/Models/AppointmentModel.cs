using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRF.Common;
using DRF.Entities;
using DRF.Services;
using NotifSystem.Web.Hubs;

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
        private NotificationService _notificationService;

        public AppointmentModel()
        {
            _doctorService = new DoctorService();
            _chamberService = new ChamberService();
            _appointmentService = new AppointmentService();
            _notificationService = new NotificationService();
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

            var isAppointmentSucceded = _appointmentService.Add(newAppointment);

            // Sent notification
            NotificationHub objNotifHub = new NotificationHub();
            Notification objNotif = new Notification();
            objNotif.SentTo = _doctorService.GetById(this.DoctorId).User.Email;

            _notificationService.AddOrUpdate(objNotif);
            //context.Configuration.ProxyCreationEnabled = false;
            //context.Notifications.Add(objNotif);
            //context.SaveChanges();

            objNotifHub.SendNotification(objNotif.SentTo);

            return isAppointmentSucceded;
        }

        public Appointment GetRecentConfirmAppointmentInfo()
        {
            return _appointmentService.GetRecentConfirmAppointmentInfoByPatientId(AuthenticatedPatientUserModel.GetPatientUserFromIdentity().Id);
        }

        public IEnumerable<Appointment> GetAllByPatientId(int? status, int? lastDays)
        {
            return _appointmentService.GetAllByPatientId(AuthenticatedPatientUserModel.GetPatientUserFromIdentity().Id, status, lastDays);
        }
    }
}