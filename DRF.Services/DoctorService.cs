using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Repository;
using DRF.Repository.Context;

namespace DRF.Services
{
    public class DoctorService
    {
        private DoctorUnitOfWork _doctorUnitOfWork;

        public DoctorService()
        {
            _doctorUnitOfWork = new DoctorUnitOfWork(new DRFDbContext());
        }
    }
}
