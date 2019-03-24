using DRF.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRF.Repository
{
    public class VacationUnitOfWork : IDisposable
    {
        private DRFDbContext _context;
        private VacationRepository _vacationRepository;
        public VacationUnitOfWork(DRFDbContext context)
        {
            _context = context;
            _vacationRepository = new VacationRepository(_context);
        }

        public VacationRepository VacationRepository => _vacationRepository;

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
