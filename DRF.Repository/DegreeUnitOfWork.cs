using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Repository.Context;

namespace DRF.Repository
{
    public class DegreeUnitOfWork : IDisposable
    {
        private DRFDbContext _context;
        private DegreeRepository _degreeRepository;
        public DegreeUnitOfWork(DRFDbContext context)
        {
            _context = context;
            _degreeRepository = new DegreeRepository(_context);
        }

        public DegreeRepository DegreeRepository => _degreeRepository;

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
