using DRF.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRF.Repository
{
    public class CityUnitOfWork : IDisposable
    {
        private DRFDbContext _context;
        private CityRepository _cityRepository;

        public CityUnitOfWork(DRFDbContext context)
        {
            _context = context;
            _cityRepository = new CityRepository(_context);
        }

        public CityRepository CityRepository => _cityRepository;

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
