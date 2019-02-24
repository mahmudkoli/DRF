using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Repository.Context;

namespace DRF.Repository
{
    public class AreaUnitOfWork : IDisposable
    {
        private DRFDbContext _context;
        private AreaRepository _areaRepository;
        public AreaUnitOfWork(DRFDbContext context)
        {
            _context = context;
            _areaRepository = new AreaRepository(_context);
        }

        public AreaRepository AreaRepository => _areaRepository;

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
