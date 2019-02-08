using DRF.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRF.Entities
{
    public class Doctor : Entity
    {
        public string Phone { get; set; } 
        public string Designation { get; set; } 
        public string Awards { get; set; } 
        public string Description { get; set; } 
        public string FathersName { get; set; } 
        public string MothersName { get; set; } 
        public string PresentAddress { get; set; } 
        public string PermanentAddress { get; set; } 
        public DateTime DateOfBirth { get; set; } 
        public int Experience { get; set; }
        public string ImageUrl { get; set; }
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public int BloodGroupId { get; set; }
        public virtual BloodGroup BloodGroup { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual IEnumerable<DoctorChamberRelation> DoctorChamberRelations { get; set; }
        public virtual IEnumerable<DoctorDegreeRelation> DoctorDegreeRelations { get; set; }
        public virtual IEnumerable<DoctorSpecialtyRelation> DoctorSpecialtyRelations { get; set; }
    }
}
