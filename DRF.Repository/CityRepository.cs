using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities;
using DRF.Repository.Base;
using DRF.Repository.Context;

namespace DRF.Repository
{
    public class CityRepository : Repository<City>
    {
        private DRFDbContext _context;

        public CityRepository(DRFDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
