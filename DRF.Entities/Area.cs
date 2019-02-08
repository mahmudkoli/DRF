using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities.Base;

namespace DRF.Entities
{
    public class Area : Entity
    {
        public string Name { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public virtual IEnumerable<Chamber> Chambers { get; set; }
    }
}
