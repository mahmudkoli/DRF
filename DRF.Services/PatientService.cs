using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Entities;
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

        public bool Add(Patient patient)
        {
            try
            {
                var newPatient = new Patient()
                {
                    UserId = patient.UserId
                };
                _patientUnitOfWork.PatientRepository.Add(newPatient);

                var isSaved = _patientUnitOfWork.Save();

                return isSaved;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public Patient GetByUserId(int userId)
        {
            return _patientUnitOfWork.PatientRepository.GetByUserId(userId);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientUnitOfWork.PatientRepository.GetAll();
        }
    }
}
