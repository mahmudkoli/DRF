using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities.Base;

namespace DRF.Entities
{
    public class Chamber : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Area")]
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public int? MapId { get; set; }  
        public Map Map { get; set; }    
        public virtual ICollection<DoctorChamberRelation> DoctorChamberRelations { get; set; }
    }
}
