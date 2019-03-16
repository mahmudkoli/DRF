using DRF.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRF.Repository
{
    public class DataUnitOfWork : IDisposable
    {
        private DRFDbContext _context;
        private GenderRepository _genderRepository;
        private BloodGroupRepository _bloodGroupRepository;

        public DataUnitOfWork(DRFDbContext context)
        {
            _context = context;
            _genderRepository = new GenderRepository(_context);
            _bloodGroupRepository = new BloodGroupRepository(_context);
        }

        public GenderRepository GenderRepository => _genderRepository;
        public BloodGroupRepository BloodGroupRepository => _bloodGroupRepository;

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
