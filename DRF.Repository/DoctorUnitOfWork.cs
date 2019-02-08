using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using DRF.Repository.Context;

namespace DRF.Repository
{
    public class DoctorUnitOfWork : IDisposable
    {
        private DRFDbContext _context;
        private DoctorRepository _doctorRepository;
        public DoctorUnitOfWork(DRFDbContext context)
        {
            _context = context;
            _doctorRepository = new DoctorRepository(_context);
        }

        public DoctorRepository DoctorRepository => _doctorRepository;

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
