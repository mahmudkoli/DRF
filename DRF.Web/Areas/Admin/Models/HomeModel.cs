using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRF.Services;

namespace DRF.Web.Areas.Admin.Models
{
    public class HomeModel
    {
        public int TotalDoctorCount { get; set; }
        public int TotalPatientCount { get; set; }
        public int TotalCityCount { get; set; }
        public int TotalAreaCount { get; set; }
        public int TotalChamberCount { get; set; }
        public int RequestedAppointmentCount { get; set; }
        public int ApprovedAppointmentCount { get; set; }
        public int RejectedAppointmentCount { get; set; }
        public int CompletedAppointmentCount { get; set; }
        public int TotalAppointmentCount { get; set; }
        public IEnumerable<Entities.Doctor> DoctorCollection { get; set; }
        public IEnumerable<Entities.Patient> PatientCollection { get; set; }

        private DoctorService _doctorService;
        private PatientService _patientService;
        private CityService _cityService;
        private AreaService _areaService;
        private ChamberService _chamberService;
        private AppointmentService _appointmentService;

        public HomeModel()
        {
            _doctorService = new DoctorService();
            _patientService = new PatientService();
            _cityService = new CityService();
            _areaService = new AreaService();
            _chamberService = new ChamberService();
            _appointmentService = new AppointmentService();

            TotalDoctorCount = _doctorService.ActiveCount();
            TotalPatientCount = _patientService.ActiveCount();
            TotalCityCount = _cityService.ActiveCount();
            TotalAreaCount = _areaService.ActiveCount();
            TotalChamberCount = _chamberService.ActiveCount();

            RequestedAppointmentCount = _appointmentService.RequestedAppointmentCount();
            ApprovedAppointmentCount = _appointmentService.ApprovedAppointmentCount();
            RejectedAppointmentCount = _appointmentService.RejectedAppointmentCount();
            CompletedAppointmentCount = _appointmentService.CompletedAppointmentCount();
            TotalAppointmentCount = _appointmentService.ActiveCount();

            DoctorCollection = _doctorService.GetAll().Take(12);
            PatientCollection = _patientService.GetAll().Take(12);
        }
    }
}