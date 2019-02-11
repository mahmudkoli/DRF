using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities.Base;

namespace DRF.Entities
{
    public class DoctorDegreeRelation : Entity
    {
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public int DegreeId { get; set; }
        public virtual Degree Degree { get; set; }
    }
}
