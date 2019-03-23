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

        public Patient GetById(int id)
        {
            return _patientUnitOfWork.PatientRepository.GetById(id);
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

        public bool AddByAdmin(Patient entity)
        {
            try
            {
                var newEntity = new Patient()
                {
                    FathersName = entity.FathersName,
                    MothersName = entity.MothersName,
                    GenderId = entity.GenderId,
                    BloodGroupId = entity.BloodGroupId,
                    Phone = entity.Phone,
                    Profession = entity.Profession,
                    PresentAddress = entity.PresentAddress,
                    PermanentAddress = entity.PermanentAddress,
                    User = entity.User,
                    DateOfBirth = entity.DateOfBirth,
                    ImageUrl = entity.ImageUrl,
                    Note = entity.Note
                };

                //----------Auto Save-------------
                newEntity.User.IsEmailVerified = true;
                newEntity.User.Password = CustomCrypto.Hash(CustomName.PatientDefaultPassword);
                newEntity.User.UserRoleId = (int)CustomEnum.UserType.Patient;

                _patientUnitOfWork.PatientRepository.Add(newEntity);
                return _patientUnitOfWork.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Update(Patient entity)
        {
            try
            {
                var existingPatient = _patientUnitOfWork.PatientRepository.GetById(entity.Id);

                existingPatient.User.Name = entity.User.Name;
                existingPatient.FathersName = entity.FathersName;
                existingPatient.MothersName = entity.MothersName;
                existingPatient.GenderId = entity.GenderId;
                existingPatient.BloodGroupId = entity.BloodGroupId;
                existingPatient.Phone = entity.Phone;
                existingPatient.Profession = entity.Profession;
                existingPatient.Note = entity.Note;
                existingPatient.PresentAddress = entity.PresentAddress;
                existingPatient.PermanentAddress = entity.PermanentAddress;
                existingPatient.DateOfBirth = entity.DateOfBirth;
                existingPatient.ImageUrl = String.IsNullOrEmpty(entity.ImageUrl) ? existingPatient.ImageUrl : entity.ImageUrl;

                _patientUnitOfWork.PatientRepository.Update(existingPatient);
                return _patientUnitOfWork.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
