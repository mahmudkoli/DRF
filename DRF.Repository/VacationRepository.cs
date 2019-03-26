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

        public IEnumerable<Vacation> GetAllByDoctorId(int doctorId)
        {
            return base.Get(x => x.DoctorId == doctorId);
        }

        public IEnumerable<Vacation> GetAllByDoctorId(int doctorId, int? chamberId, DateTime? fromDate, DateTime? toDate)
        {
            var data = base.Get(x => x.DoctorId == doctorId);
            data = chamberId == null ? data : data.Where(x => x.ChamberId == chamberId);
            data = fromDate == null ? data : data.Where(x => x.StartDate >= fromDate);
            data = toDate == null ? data : data.Where(x => x.EndDate <= toDate);
            return data;
        }
    }
}
