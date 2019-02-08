using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRF.Entities;

namespace DRF.Web.Areas.Doctor.Models
{
    public class DoctorModel : Entities.Doctor
    {
        public IEnumerable<Gender> GenderCollection { get; set; }
        public IEnumerable<Specialty> SpecialtyCollection { get; set; }
        public IEnumerable<BloodGroup> BloodGroupCollection { get; set; }
        public IEnumerable<Degree> DegreeCollection { get; set; }
        public IEnumerable<Chamber> ChamberCollection { get; set; }
        public IEnumerable<int> ChamberSelectedIds { get; set; }
        public IEnumerable<int> DegreeSelectedIds { get; set; }
        public IEnumerable<int> SpecialtySelectedIds { get; set; }
        public HttpPostedFileBase ImageFileBase { get; set; }
        public DoctorModel()
        {
            SpecialtyCollection = new List<Specialty>(){new Specialty(){Id = 1, Name = "ADS"}};
            DegreeCollection = new List<Degree>() { new Degree() { Id = 1, Name = "ADS" } };
            ChamberCollection = new List<Chamber>() { new Chamber() { Id = 1, Name = "ADS" } };
            GenderCollection = new List<Gender>() { new Gender() { Id = 1, Name = "Male" } };
            BloodGroupCollection = new List<BloodGroup>() { new BloodGroup() { Id = 1, Name = "A+" } };
        }
    }
}