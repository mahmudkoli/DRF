using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities.Base;

namespace DRF.Entities
{
    public class Chamber : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public int MapId { get; set; }  
        public Map Map { get; set; }    
        public virtual IEnumerable<DoctorChamberRelation> DoctorChamberRelations { get; set; }
    }
}
