using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities.Base;

namespace DRF.Entities
{
    public class Map : Entity
    {
        [Required]
        public string Lat { get; set; }
        [Required]
        public string Long { get; set; }    
    }
}
