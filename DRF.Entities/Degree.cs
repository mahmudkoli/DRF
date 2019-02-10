using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities.Base;

namespace DRF.Entities
{
    public class Degree : Entity
    {
        [Required]
        public string Name { get; set; }
        public string Details { get; set; }
        public virtual ICollection<DoctorDegreeRelation> DoctorDegreeRelations { get; set; }
    }
}
