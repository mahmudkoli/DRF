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

        private DoctorService _doctorService;
        private ChamberService _chamberService;
        private SpecialtyService _specialtyService;
        private DegreeService _degreeService;
        private DataService _dataService;

        public DoctorModel()
        {
            _doctorService = new DoctorService();
            _chamberService = new ChamberService();
            _degreeService = new DegreeService();
            _specialtyService = new SpecialtyService();
            _dataService = new DataService();

            SpecialtyCollection = _specialtyService.GetAll();
            DegreeCollection = _degreeService.GetAll();
            ChamberCollection = _chamberService.GetAll();
            GenderCollection = _dataService.GetAllGender(); ;
            BloodGroupCollection = _dataService.GetAllBloodGroup();
            this.User = this.User??new User();
        }

        public DoctorModel(int id) : this()
        {
            var existingDoctor = _doctorService.GetById(id);
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
            }

        }

        public Entities.Doctor GetById(int id)
        {
            return _doctorService.GetById(id);
        }

        public bool Add()
        {
            try
            {
                this.DoctorChamberRelations = this.ChamberSelectedIdsToDoctorChamberRelations().ToList();
                this.DoctorSpecialtyRelations = this.SpecialtySelectedIdsToDoctorSpecialtyRelations().ToList();
                this.DoctorDegreeRelations = this.DegreeSelectedIdsToDoctorDegreeRelations().ToList();
                this.ImageUrl = CustomFile.SaveImageFile(this.ImageFileBase, this.User.Name, this.Id, "Doctor");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return _doctorService.AddByAdmin(this);
        }

        public bool IsEmailExist(string email)
        {
            return _doctorService.IsEmailExist(email);
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
                this.ImageUrl = CustomFile.SaveImageFile(this.ImageFileBase, this.User.Name, this.Id, "Doctor");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return _doctorService.Update(this);
        }

        public IEnumerable<Entities.Doctor> GetAll()
        {
            return _doctorService.GetAll();
        }

        public IEnumerable<Entities.Doctor> GetAll(string name, byte? status)
        {
            return _doctorService.GetAll(name, status);
        }

        public bool ChangeStatus(int id)
        {
            return _doctorService.ChangeStatus(id);
        }
    }
}