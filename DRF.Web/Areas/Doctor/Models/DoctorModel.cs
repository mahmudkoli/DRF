using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRF.Common;
using DRF.Entities;
using DRF.Services;

namespace DRF.Web.Areas.Doctor.Models
{
    public class DoctorModel : Entities.Doctor
    {
        public IEnumerable<Gender> GenderCollection { get; set; }
        public IEnumerable<Specialty> SpecialtyCollection { get; set; }
        public IEnumerable<BloodGroup> BloodGroupCollection { get; set; }
        public IEnumerable<Degree> DegreeCollection { get; set; }
        public IEnumerable<Chamber> ChamberCollection { get; set; }
        [Display(Name = "Chamber")]
        public IEnumerable<int> ChamberSelectedIds { get; set; }
        [Display(Name = "Degree")]
        public IEnumerable<int> DegreeSelectedIds { get; set; }
        [Display(Name = "Specialty")]
        public IEnumerable<int> SpecialtySelectedIds { get; set; }
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

        private DoctorService _doctorService;
        private ChamberService _chamberService;
        private SpecialtyService _specialtyService;
        private DegreeService _degreeService;
        private AppointmentService _appointmentService;

        public DoctorModel()
        {
            _doctorService = new DoctorService();
            _chamberService = new ChamberService();
            _degreeService = new DegreeService();
            _specialtyService = new SpecialtyService();
            _appointmentService = new AppointmentService();

            SpecialtyCollection = _specialtyService.GetAll();
            DegreeCollection = _degreeService.GetAll();
            ChamberCollection = _chamberService.GetAll();

            GenderCollection = new List<Gender>() { new Gender() { Id = 1, Name = "Male" },
                new Gender() { Id = 2, Name = "Female" }, new Gender() { Id = 3, Name = "Others" } };

            BloodGroupCollection = new List<BloodGroup>() { new BloodGroup() { Id = 1, Name = "A+" },
                new BloodGroup() { Id = 2, Name = "A-" }, new BloodGroup() { Id = 3, Name = "AB+" } };
        }

        public DoctorModel(int id) : this()
        {
            var existingDoctor = _doctorService.GetByUserId(AuthenticatedDoctorUserModel.GetUserFromIdentity().Id);
            if (existingDoctor != null)
            {
                this.Id = existingDoctor.Id;
                this.User = existingDoctor.User;
                this.UserId = existingDoctor.UserId;
                this.FathersName = existingDoctor.FathersName;
                this.MothersName = existingDoctor.MothersName;
                this.PresentAddress = existingDoctor.PresentAddress;
                this.PermanentAddress = existingDoctor.PermanentAddress;
                this.Awards = existingDoctor.Awards;
                this.BloodGroupId = existingDoctor.BloodGroupId;
                this.BloodGroup = existingDoctor.BloodGroup;
                this.DateOfBirth = existingDoctor.DateOfBirth;
                this.Description = existingDoctor.Description;
                this.Designation = existingDoctor.Designation;
                this.Phone = existingDoctor.Phone;
                this.Status = existingDoctor.Status;
                this.UpdatedAt = existingDoctor.UpdatedAt;
                this.Experience = existingDoctor.Experience;
                this.GenderId = existingDoctor.GenderId;
                this.Gender = existingDoctor.Gender;
                this.ImageUrl = existingDoctor.ImageUrl;
                this.DoctorChamberRelations = existingDoctor.DoctorChamberRelations;
                this.DoctorDegreeRelations = existingDoctor.DoctorDegreeRelations;
                this.DoctorSpecialtyRelations = existingDoctor.DoctorSpecialtyRelations;

                this.ChamberSelectedIds = existingDoctor.DoctorChamberRelations.Select(x => x.ChamberId);
                this.SpecialtySelectedIds = existingDoctor.DoctorSpecialtyRelations.Select(x => x.SpecialtyId);
                this.DegreeSelectedIds = existingDoctor.DoctorDegreeRelations.Select(x => x.DegreeId);

                _appointmentCollection = _appointmentService.GetAllByDoctorId(this.Id);
                ExecuteAppoinmentCount();
            }

        }

        public bool Add()
        {
            try
            { 
                this.UserId = AuthenticatedDoctorUserModel.GetUserFromIdentity().Id;
                this.DoctorChamberRelations = this.ChamberSelectedIdsToDoctorChamberRelations().ToList();
                this.DoctorSpecialtyRelations = this.SpecialtySelectedIdsToDoctorSpecialtyRelations().ToList();
                this.DoctorDegreeRelations = this.DegreeSelectedIdsToDoctorDegreeRelations().ToList();
                this.ImageUrl = CustomFile.SaveImageFile(this.ImageFileBase,
                    AuthenticatedDoctorUserModel.GetUserFromIdentity().Name,
                    AuthenticatedDoctorUserModel.GetUserFromIdentity().Id, "Doctor");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return _doctorService.Add(this);
        }

        public bool IsExist()
        {
            return AuthenticatedDoctorUserModel.GetDoctorUserFromIdentity() != null;
        }

        public IEnumerable<DoctorChamberRelation> ChamberSelectedIdsToDoctorChamberRelations()
        {
            IEnumerable<DoctorChamberRelation> listEntities;

            listEntities = this.ChamberSelectedIds != null && this.ChamberSelectedIds.Any() ?
                this.ChamberSelectedIds.Select(x => new DoctorChamberRelation() { ChamberId = x }) : null;

            return listEntities;
        }

        public IEnumerable<DoctorSpecialtyRelation> SpecialtySelectedIdsToDoctorSpecialtyRelations()
        {
            IEnumerable<DoctorSpecialtyRelation> listEntities;

            listEntities = this.SpecialtySelectedIds != null && this.SpecialtySelectedIds.Any() ?
                this.SpecialtySelectedIds.Select(x => new DoctorSpecialtyRelation() { SpecialtyId = x }) : null;

            return listEntities;
        }

        public IEnumerable<DoctorDegreeRelation> DegreeSelectedIdsToDoctorDegreeRelations()
        {
            IEnumerable<DoctorDegreeRelation> listEntities;

            listEntities = this.DegreeSelectedIds != null && this.DegreeSelectedIds.Any() ?
                this.DegreeSelectedIds.Select(x => new DoctorDegreeRelation() { DegreeId = x }) : null;

            return listEntities;
        }

        public bool Update()
        {
            try
            { 
                this.DoctorChamberRelations = this.ChamberSelectedIdsToDoctorChamberRelations().ToList();
                this.DoctorSpecialtyRelations = this.SpecialtySelectedIdsToDoctorSpecialtyRelations().ToList();
                this.DoctorDegreeRelations = this.DegreeSelectedIdsToDoctorDegreeRelations().ToList();
                this.ImageUrl = CustomFile.SaveImageFile(this.ImageFileBase,
                    AuthenticatedDoctorUserModel.GetUserFromIdentity().Name,
                    AuthenticatedDoctorUserModel.GetUserFromIdentity().Id, "Doctor");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return _doctorService.Update(this);
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