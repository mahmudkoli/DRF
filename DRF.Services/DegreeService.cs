using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Repository;
using DRF.Repository.Context;

namespace DRF.Services
{
    public class DegreeService
    {
        private DegreeUnitOfWork _degreeUnitOfWork;

        public DegreeService()
        {
            _degreeUnitOfWork = new DegreeUnitOfWork(new DRFDbContext());
        }
    }
}
