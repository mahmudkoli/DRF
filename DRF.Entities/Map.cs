using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities.Base;

namespace DRF.Entities
{
    public class Map : Entity
    {
        public string Lat { get; set; }
        public string Long { get; set; }    
    }
}
