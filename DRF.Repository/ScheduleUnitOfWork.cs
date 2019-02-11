using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Repository.Context;

namespace DRF.Repository
{
    public class ScheduleUnitOfWork : IDisposable
    {
        private DRFDbContext _context;
        private ScheduleRepository _scheduleRepository;
        public ScheduleUnitOfWork(DRFDbContext context)
        {
            _context = context;
            _scheduleRepository = new ScheduleRepository(_context);
        }

        public ScheduleRepository ScheduleRepository => _scheduleRepository;

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
