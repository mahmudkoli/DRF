using DRF.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRF.Entities
{
    public class Specialty : Entity
    {
        public string Name { get; set; }
        public string Disease { get; set; }
        public string Details { get; set; }
        public virtual IEnumerable<DoctorSpecialtyRelation> DoctorSpecialtyRelations { get; set; }
    }
}
