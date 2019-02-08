using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Repository.Context;

namespace DRF.Repository
{
    public class PatientUnitOfWork : IDisposable
    {
        private DRFDbContext _context;
        private PatientRepository _patientRepository;
        public PatientUnitOfWork(DRFDbContext context)
        {
            _context = context;
            _patientRepository = new PatientRepository(_context);
        }

        public PatientRepository PatientRepository => _patientRepository;

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
