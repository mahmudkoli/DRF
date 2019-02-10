using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities.Base;

namespace DRF.Entities
{
    public class Vacation : Entity
    {
        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        [Required]
        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        [Required]
        [Display(Name = "Chamber")]
        public int ChamberId { get; set; }
        public virtual Chamber Chamber { get; set; }

    }
}
