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

        private PatientService _patientService;
        private ChamberService _chamberService;
        private SpecialtyService _specialtyService;
        private DegreeService _degreeService;
        private DataService _dataService;
        private UserService _userService;

        public PatientModel()
        {
            _patientService = new PatientService();
            _chamberService = new ChamberService();
            _degreeService = new DegreeService();
            _specialtyService = new SpecialtyService();
            _dataService = new DataService();
            _userService = new UserService();
            
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
                this.Status = existingPatient.Status;
                this.UpdatedAt = existingPatient.UpdatedAt;
                this.GenderId = existingPatient.GenderId;
                this.Gender = existingPatient.Gender;
                this.ImageUrl = existingPatient.ImageUrl;
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
    }
}