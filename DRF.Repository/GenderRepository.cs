using DRF.Entities;
using DRF.Repository.Base;
using DRF.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRF.Repository
{
    public class GenderRepository
    {
        private DRFDbContext _context;
        public GenderRepository(DRFDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Gender> GetAll()
        {
            return _context.Genders;
        }
    }
}
