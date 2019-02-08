using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Repository;
using DRF.Repository.Context;

namespace DRF.Services
{
    public class PatientService
    {
        private PatientUnitOfWork _patientUnitOfWork;

        public PatientService()
        {
            _patientUnitOfWork = new PatientUnitOfWork(new DRFDbContext());
        }
    }
}
