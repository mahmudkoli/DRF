using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Repository.Context;

namespace DRF.Repository
{
    public class ChamberUnitOfWork : IDisposable
    {
        private DRFDbContext _context;
        private ChamberRepository _chamberRepository;
        public ChamberUnitOfWork(DRFDbContext context)
        {
            _context = context;
            _chamberRepository = new ChamberRepository(_context);
        }

        public ChamberRepository ChamberRepository => _chamberRepository;

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
