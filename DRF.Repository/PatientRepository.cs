using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities;
using DRF.Repository.Base;
using DRF.Repository.Context;

namespace DRF.Repository
{
    public class PatientRepository : Repository<Patient>
    {
        private DRFDbContext _context;
        public PatientRepository(DRFDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
