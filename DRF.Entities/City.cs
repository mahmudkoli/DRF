using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities.Base;

namespace DRF.Entities
{
    public class City : Entity
    {
        public string Name { get; set; }
        public virtual IEnumerable<Area> Areas { get; set; }    
    }
}
