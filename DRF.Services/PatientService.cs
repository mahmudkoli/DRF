using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRF.Common;
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

        public int ActiveCount()
        {
            return _patientUnitOfWork.PatientRepository.ActiveCount();
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientUnitOfWork.PatientRepository.GetAll();
        }

        public IEnumerable<Patient> GetAll(string name, byte? status)
        {
            var data = _patientUnitOfWork.PatientRepository.Get(x => true);
            data = string.IsNullOrEmpty(name) ? data : data.Where(x => x.User.Name.ToLower().Contains(name.ToLower()));
            data = status == null ? data : data.Where(x => x.Status == status);
            return data.OrderByDescending(x => (x.UpdatedAt == null ? x.CreatedAt : x.UpdatedAt));
        }

        public bool ChangeStatus(int id)
        {
            var doctor = _patientUnitOfWork.PatientRepository.GetById(id);
            doctor.Status = doctor.Status == (byte)CustomEnum.Status.Active ?
                (byte)CustomEnum.Status.Inactive : (byte)CustomEnum.Status.Active;
            doctor.UpdatedAt = DateTime.Now;
            return _patientUnitOfWork.Save();
        }
    }
}
