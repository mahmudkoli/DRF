using DRF.Entities;
using DRF.Repository.Base;
using DRF.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRF.Repository
{
    public class BloodGroupRepository
    {
        private DRFDbContext _context;
        public BloodGroupRepository(DRFDbContext context)
        {
            _context = context;
        }
        public IEnumerable<BloodGroup> GetAll()
        {
            return _context.BloodGroups;
        }
    }
}
