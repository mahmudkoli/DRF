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
    public class ScheduleRepository : Repository<Schedule>
    {
        private DRFDbContext _context;
        public ScheduleRepository(DRFDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
