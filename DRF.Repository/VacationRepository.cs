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
    public class VacationRepository : Repository<Vacation>
    {
        private DRFDbContext _context;
        public VacationRepository(DRFDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
