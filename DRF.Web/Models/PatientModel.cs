using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;
using DRF.Common;
using DRF.Entities;
using DRF.Services;

namespace DRF.Web.Models
{
    public class PatientModel : Patient
    {
        public IEnumerable<Gender> GenderCollection { get; set; }
        public IEnumerable<BloodGroup> BloodGroupCollection { get; set; }

        private PatientService _patientService;
        private DataService _dataService;

        public HttpPostedFileBase ImageFileBase { get; set; }

        public PatientModel()
        {
            _patientService = new PatientService();
            _dataService = new DataService();

            GenderCollection = _dataService.GetAllGender();
            BloodGroupCollection = _dataService.GetAllBloodGroup();
        }

        public PatientModel(int id) : this()
        {
            var existingPatient = _patientService.GetByUserId(AuthenticatedPatientUserModel.GetUserFromIdentity().Id);
            if (existingPatient != null)
            {
                this.Id = existingPatient.Id;
                this.UserId = existingPatient.UserId;
                this.User = existingPatient.User;
                this.FathersName = existingPatient.FathersName;
                this.MothersName = existingPatient.MothersName;
                this.PresentAddress = existingPatient.PresentAddress;
                this.PermanentAddress = existingPatient.PermanentAddress;
                this.Phone = existingPatient.Phone;
                this.ImageUrl = existingPatient.ImageUrl;
                this.Profession = existingPatient.Profession;
                this.Note = existingPatient.Note;
                this.GenderId = existingPatient.GenderId;
                this.BloodGroupId = existingPatient.BloodGroupId;
                this.BloodGroup = existingPatient.BloodGroup;
                this.Gender = existingPatient.Gender;
                this.DateOfBirth = existingPatient.DateOfBirth;
                this.Status = existingPatient.Status;
                this.CreatedAt = existingPatient.CreatedAt;
                this.UpdatedAt = existingPatient.UpdatedAt;
            }
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
    }
}