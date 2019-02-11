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
    public class AppointmentRepository : Repository<Appointment>
    {
        private DRFDbContext _context;
        public AppointmentRepository(DRFDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
