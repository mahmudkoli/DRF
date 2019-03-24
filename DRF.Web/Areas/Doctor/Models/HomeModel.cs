using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRF.Common;
using DRF.Entities;
using DRF.Services;

namespace DRF.Web.Areas.Doctor.Models
{
    public class HomeModel
    {
        public int TotalDoctorCount { get; set; }
        public int TotalPatientCount { get; set; }
        public int TotalCityCount { get; set; }
        public int TotalAreaCount { get; set; }
        public int TotalChamberCount { get; set; }
        public int RequestedAppointmentCount { get; set; }

        public bool IsExist()
        {
            return AuthenticatedDoctorUserModel.GetDoctorUserFromIdentity() != null;
        }

        public int ApprovedAppointmentCount { get; set; }
        public int RejectedAppointmentCount { get; set; }
        public int CompletedAppointmentCount { get; set; }
        public int TotalAppointmentCount { get; set; }
        public int RequestedAppointmentCountByYear { get; set; }
        public int ApprovedAppointmentCountByYear { get; set; }
        public int RejectedAppointmentCountByYear { get; set; }
        public int CompletedAppointmentCountByYear { get; set; }
        public int TotalAppointmentCountByYear { get; set; }
        public IEnumerable<Entities.Doctor> DoctorCollection { get; set; }
        public IEnumerable<Entities.Patient> PatientCollection { get; set; }

        private IEnumerable<Appointment> _appointmentCollection { get; set; }

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

            RequestedAppointmentCountByYear = _appointmentService.RequestedAppointmentCountByYear(DateTime.Now.Year);
            ApprovedAppointmentCountByYear = _appointmentService.ApprovedAppointmentCountByYear(DateTime.Now.Year);
            RejectedAppointmentCountByYear = _appointmentService.RejectedAppointmentCountByYear(DateTime.Now.Year);
            CompletedAppointmentCountByYear = _appointmentService.CompletedAppointmentCountByYear(DateTime.Now.Year);
            TotalAppointmentCountByYear = _appointmentService.ActiveCountByYear(DateTime.Now.Year);

            DoctorCollection = _doctorService.GetAll().Take(12);
            PatientCollection = _patientService.GetAll().Take(12);

            _appointmentCollection = _appointmentService.GetAllByDoctorId(AuthenticatedDoctorUserModel.GetDoctorUserFromIdentity().Id);
            ExecuteAppoinmentCount();
        }

        private void ExecuteAppoinmentCount()
        {
            if (_appointmentCollection != null && _appointmentCollection.Count() > 0)
            {

                RequestedAppointmentCount = _appointmentCollection
                    .Where(x => x.AppointmentStatus == (byte)CustomEnum.AppointmentStatus.Requested).Count();
                ApprovedAppointmentCount = _appointmentCollection
                    .Where(x => x.AppointmentStatus == (byte)CustomEnum.AppointmentStatus.Approved).Count();
                RejectedAppointmentCount = _appointmentCollection
                    .Where(x => x.AppointmentStatus == (byte)CustomEnum.AppointmentStatus.Rejected).Count();
                CompletedAppointmentCount = _appointmentCollection
                    .Where(x => x.AppointmentStatus == (byte)CustomEnum.AppointmentStatus.Completed).Count();
                TotalAppointmentCount = _appointmentCollection.Count();

                RequestedAppointmentCountByYear = _appointmentCollection
                    .Where(x => x.AppointmentStatus == (byte)CustomEnum.AppointmentStatus.Requested &&
                    x.AppointmentDate.Year == DateTime.Now.Year).Count();
                ApprovedAppointmentCountByYear = _appointmentCollection
                    .Where(x => x.AppointmentStatus == (byte)CustomEnum.AppointmentStatus.Approved &&
                    x.AppointmentDate.Year == DateTime.Now.Year).Count();
                RejectedAppointmentCountByYear = _appointmentCollection
                    .Where(x => x.AppointmentStatus == (byte)CustomEnum.AppointmentStatus.Rejected &&
                    x.AppointmentDate.Year == DateTime.Now.Year).Count();
                CompletedAppointmentCountByYear = _appointmentCollection
                    .Where(x => x.AppointmentStatus == (byte)CustomEnum.AppointmentStatus.Completed &&
                    x.AppointmentDate.Year == DateTime.Now.Year).Count();
                TotalAppointmentCountByYear = _appointmentCollection
                    .Where(x => x.AppointmentDate.Year == DateTime.Now.Year).Count();
            }
        }

        public IEnumerable<Doctor.Models.AppointmentChartModel> GetAllAppointmentChartData()
        {
            var appointmentData = _appointmentService.GetAllByDoctorId(AuthenticatedDoctorUserModel.GetDoctorUserFromIdentity().Id, DateTime.Now.Year);
            var appChartData = appointmentData.GroupBy(x => x.AppointmentStatus).Select(y => new Doctor.Models.AppointmentChartModel()
            {
                AppointmentStatus = ((CustomEnum.AppointmentStatus)y.Key).ToString(),
                Jan = y.Where(t => t.CreatedAt.Value.Month == (int)CustomEnum.Month.Jan).Count(),
                Feb = y.Where(t => t.CreatedAt.Value.Month == (int)CustomEnum.Month.Feb).Count(),
                Mar = y.Where(t => t.CreatedAt.Value.Month == (int)CustomEnum.Month.Mar).Count(),
                Apr = y.Where(t => t.CreatedAt.Value.Month == (int)CustomEnum.Month.Apr).Count(),
                May = y.Where(t => t.CreatedAt.Value.Month == (int)CustomEnum.Month.May).Count(),
                Jun = y.Where(t => t.CreatedAt.Value.Month == (int)CustomEnum.Month.Jun).Count(),
                Jul = y.Where(t => t.CreatedAt.Value.Month == (int)CustomEnum.Month.Jul).Count(),
                Aug = y.Where(t => t.CreatedAt.Value.Month == (int)CustomEnum.Month.Aug).Count(),
                Sep = y.Where(t => t.CreatedAt.Value.Month == (int)CustomEnum.Month.Sep).Count(),
                Oct = y.Where(t => t.CreatedAt.Value.Month == (int)CustomEnum.Month.Oct).Count(),
                Nov = y.Where(t => t.CreatedAt.Value.Month == (int)CustomEnum.Month.Nov).Count(),
                Dec = y.Where(t => t.CreatedAt.Value.Month == (int)CustomEnum.Month.Dec).Count()
            }).ToList();

            if (!appChartData.Any(x => x.AppointmentStatus == (CustomEnum.AppointmentStatus.Requested).ToString()))
                appChartData.Add(new Doctor.Models.AppointmentChartModel() { AppointmentStatus = (CustomEnum.AppointmentStatus.Requested).ToString() });

            if (!appChartData.Any(x => x.AppointmentStatus == (CustomEnum.AppointmentStatus.Approved).ToString()))
                appChartData.Add(new Doctor.Models.AppointmentChartModel() { AppointmentStatus = (CustomEnum.AppointmentStatus.Approved).ToString() });

            if (!appChartData.Any(x => x.AppointmentStatus == (CustomEnum.AppointmentStatus.Rejected).ToString()))
                appChartData.Add(new Doctor.Models.AppointmentChartModel() { AppointmentStatus = (CustomEnum.AppointmentStatus.Rejected).ToString() });

            if (!appChartData.Any(x => x.AppointmentStatus == (CustomEnum.AppointmentStatus.Completed).ToString()))
                appChartData.Add(new Doctor.Models.AppointmentChartModel() { AppointmentStatus = (CustomEnum.AppointmentStatus.Completed).ToString() });


            return appChartData;
        }
    }

    public class AppointmentChartModel
    {
        public string AppointmentStatus { get; set; }
        public int Jan { get; set; }
        public int Feb { get; set; }
        public int Mar { get; set; }
        public int Apr { get; set; }
        public int May { get; set; }
        public int Jun { get; set; }
        public int Jul { get; set; }
        public int Aug { get; set; }
        public int Sep { get; set; }
        public int Oct { get; set; }
        public int Nov { get; set; }
        public int Dec { get; set; }
    }
}