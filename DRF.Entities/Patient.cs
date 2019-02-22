using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities.Base;

namespace DRF.Entities
{
    public class Patient : Entity
    {
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Phone { get; set; }
        public string Profession { get; set; }
        public string Note { get; set; }
        [Display(Name = "Father's Name")]
        public string FathersName { get; set; }
        [Display(Name = "Mother's Name")]
        public string MothersName { get; set; }
        [Display(Name = "Present Address")]
        public string PresentAddress { get; set; }
        [Display(Name = "Permanent Address")]
        public string PermanentAddress { get; set; }
        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        [Display(Name = "Gender")]
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        [Display(Name = "Blood Group")]
        public int? BloodGroupId { get; set; }
        public virtual BloodGroup BloodGroup { get; set; }
    }
}
