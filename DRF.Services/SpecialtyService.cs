using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Repository;
using DRF.Repository.Context;

namespace DRF.Services
{
    public class SpecialtyService
    {
        private SpecialtyUnitOfWork _specialtyUnitOfWork;

        public SpecialtyService()
        {
            _specialtyUnitOfWork = new SpecialtyUnitOfWork(new DRFDbContext());
        }
    }
}
