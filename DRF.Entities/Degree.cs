using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities.Base;

namespace DRF.Entities
{
    public class Degree : Entity
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public virtual IEnumerable<DoctorDegreeRelation> DoctorDegreeRelations { get; set; }
    }
}
