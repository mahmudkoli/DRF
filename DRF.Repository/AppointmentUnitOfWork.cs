using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Repository.Context;

namespace DRF.Repository
{
    public class AppointmentUnitOfWork : IDisposable
    {
        private DRFDbContext _context;
        private AppointmentRepository _appointmentRepository;
        public AppointmentUnitOfWork(DRFDbContext context)
        {
            _context = context;
            _appointmentRepository = new AppointmentRepository(_context);
        }

        public AppointmentRepository AppointmentRepository => _appointmentRepository;

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
