using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Repository.Context;

namespace DRF.Repository
{
    public class SpecialtyUnitOfWork : IDisposable
    {
        private DRFDbContext _context;
        private SpecialtyRepository _specialtyRepository;
        public SpecialtyUnitOfWork(DRFDbContext context)
        {
            _context = context;
            _specialtyRepository = new SpecialtyRepository(_context);
        }

        public SpecialtyRepository SpecialtyRepository => _specialtyRepository;

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
