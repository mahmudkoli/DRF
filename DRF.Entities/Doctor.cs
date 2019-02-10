using DRF.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRF.Entities
{
    public class Doctor : Entity
    {
        [Required]
        public string Phone { get; set; } 
        public string Designation { get; set; } 
        public string Awards { get; set; } 
        public string Description { get; set; } 
        [Required]
        [Display(Name = "Father's Name")]
        public string FathersName { get; set; }
        [Required]
        [Display(Name = "Mother's Name")]
        public string MothersName { get; set; }
        [Required]
        [Display(Name = "Present Address")]
        public string PresentAddress { get; set; }
        [Required]
        [Display(Name = "Permanent Address")]
        public string PermanentAddress { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; } 
        public int? Experience { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        [Display(Name = "Blood Group")]
        public int? BloodGroupId { get; set; }
        public virtual BloodGroup BloodGroup { get; set; }
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<DoctorChamberRelation> DoctorChamberRelations { get; set; }
        public virtual ICollection<DoctorDegreeRelation> DoctorDegreeRelations { get; set; }
        public virtual ICollection<DoctorSpecialtyRelation> DoctorSpecialtyRelations { get; set; }
    }
}
