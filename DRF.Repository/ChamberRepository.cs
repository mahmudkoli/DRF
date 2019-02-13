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
    public class ChamberRepository : Repository<Chamber>
    {
        private DRFDbContext _context;
        public ChamberRepository(DRFDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Chamber> GetAllByDoctorId(int doctorId)
        {
            return _context.DoctorChamberRelations.Where(x => x.DoctorId == doctorId).Select(y => y.Chamber);
        }
    }
}
