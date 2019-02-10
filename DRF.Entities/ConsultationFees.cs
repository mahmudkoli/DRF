using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities.Base;

namespace DRF.Entities
{
    public class ConsultationFees : Entity
    {
        public double New { get; set; }
        public double? Regular { get; set; }
        public double? Checkup { get; set; }
        [Required]
        [Display(Name = "Doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
