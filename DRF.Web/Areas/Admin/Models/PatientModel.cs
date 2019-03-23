using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DRF.Common;
using DRF.Entities;
using DRF.Services;

namespace DRF.Web.Areas.Admin.Models
{
    public class PatientModel : Patient
    {
        public IEnumerable<Gender> GenderCollection { get; set; }
        public IEnumerable<BloodGroup> BloodGroupCollection { get; set; }
        [Display(Name = "Image")]
        public HttpPostedFileBase ImageFileBase { get; set; }

        public int RequestedAppointmentCount { get; set; }
        public int ApprovedAppointmentCount { get; set; }
        public int RejectedAppointmentCount { get; set; }
        public int CompletedAppointmentCount { get; set; }
        public int TotalAppointmentCount { get; set; }
        public int RequestedAppointmentCountByYear { get; set; }
        public int ApprovedAppointmentCountByYear { get; set; }
        public int RejectedAppointmentCountByYear { get; set; }
        public int CompletedAppointmentCountByYear { get; set; }
        public int TotalAppointmentCountByYear { get; set; }

        private IEnumerable<Appointment> _appointmentCollection { get; set; }

        private PatientService _patientService;
        private ChamberService _chamberService;
        private SpecialtyService _specialtyService;
        private DegreeService _degreeService;
        private DataService _dataService;
        private UserService _userService;
        private AppointmentService _appointmentService;

        public PatientModel()
        {
            _patientService = new PatientService();
            _chamberService = new ChamberService();
            _degreeService = new DegreeService();
            _specialtyService = new SpecialtyService();
            _dataService = new DataService();
            _userService = new UserService();
            _appointmentService = new AppointmentService();

            GenderCollection = _dataService.GetAllGender(); ;
            BloodGroupCollection = _dataService.GetAllBloodGroup();
            this.User = this.User ?? new User();
        }

        public PatientModel(int id) : this()
        {
            var existingPatient = _patientService.GetById(id);
            if (existingPatient != null)
            {
                this.Id = existingPatient.Id;
                this.User = existingPatient.User;
                this.UserId = existingPatient.UserId;
                this.FathersName = existingPatient.FathersName;
                this.MothersName = existingPatient.MothersName;
                this.PresentAddress = existingPatient.PresentAddress;
                this.PermanentAddress = existingPatient.PermanentAddress;
                this.BloodGroupId = existingPatient.BloodGroupId;
                this.BloodGroup = existingPatient.BloodGroup;
                this.DateOfBirth = existingPatient.DateOfBirth;
                this.Phone = existingPatient.Phone;
                this.Profession = existingPatient.Profession;
                this.Note = existingPatient.Note;
                this.Status = existingPatient.Status;
                this.UpdatedAt = existingPatient.UpdatedAt;
                this.GenderId = existingPatient.GenderId;
                this.Gender = existingPatient.Gender;
                this.ImageUrl = existingPatient.ImageUrl;

                _appointmentCollection = _appointmentService.GetAllByPatientId(this.Id);
                ExecuteAppoinmentCount();
            }

        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientService.GetAll();
        }

        public IEnumerable<Entities.Patient> GetAll(string name, byte? status)
        {
            return _patientService.GetAll(name, status);
        }

        public bool ChangeStatus(int id)
        {
            return _patientService.ChangeStatus(id);
        }

        public bool Add()
        {
            try
            {
                this.ImageUrl = CustomFile.SaveImageFile(this.ImageFileBase, this.User.Name, this.Id, "Patient");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return _patientService.AddByAdmin(this);
        }

        public bool Update()
        {
            try
            {
                this.ImageUrl = CustomFile.SaveImageFile(this.ImageFileBase, this.User.Name, this.Id, "Patient");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return _patientService.Update(this);
        }

        public bool IsEmailExist(string email)
        {
            return _userService.IsEmailExist(email);
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
    }
}