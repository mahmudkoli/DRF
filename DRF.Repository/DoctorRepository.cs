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
    public class DoctorRepository : Repository<Doctor>
    {
        private DRFDbContext _context;
        public DoctorRepository(DRFDbContext context) : base(context)
        {
            _context = context;
        }

        public Doctor GetByUserId(int userId)
        {
            return base.Get(x => x.UserId == userId).FirstOrDefault();
        }
    }
}
