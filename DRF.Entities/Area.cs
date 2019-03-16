using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities.Base;

namespace DRF.Entities
{
    public class Area : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "City")]
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Chamber> Chambers { get; set; }
    }
}
