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

        public IEnumerable<Schedule> GetAllByDoctorId(int doctorId)
        {
            return base.Get(x => x.DoctorId == doctorId);
        }

        public IEnumerable<Schedule> GetDoctorAvailableDay(int doctorId, int chamberId)
        {
            return base.Get(x => x.DoctorId == doctorId && x.ChamberId == chamberId);
        }

        public IEnumerable<Schedule> GetDoctorAvailableTime(int doctorId, int chamberId, int day)
        {
            return base.Get(x => x.DoctorId == doctorId && x.ChamberId == chamberId && x.Day == day);
        }

        public IEnumerable<Schedule> GetAllByDoctorId(int doctorId, int? chamberId, int? day)
        {
            var data = base.Get(x => x.DoctorId == doctorId);
            data = chamberId == null ? data : data.Where(x => x.ChamberId == chamberId);
            data = day == null ? data : data.Where(x => x.Day == day);
            return data;
        }
    }
}
