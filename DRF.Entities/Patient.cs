using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities.Base;

namespace DRF.Entities
{
    public class Patient : Entity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
