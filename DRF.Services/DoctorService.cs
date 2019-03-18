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
    public class DoctorService
    {
        private DoctorUnitOfWork _doctorUnitOfWork;
        private UserService _userService;

        public DoctorService()
        {
            _doctorUnitOfWork = new DoctorUnitOfWork(new DRFDbContext());
            _userService = new UserService();
        }

        public bool Add(Doctor entity)
        {
            try
            {
                var newEntity = new Doctor()
                {
                    FathersName = entity.FathersName,
                    MothersName = entity.MothersName,
                    GenderId = entity.GenderId,
                    BloodGroupId = entity.BloodGroupId,
                    Designation = entity.Designation,
                    Description = entity.Description,
                    Phone = entity.Phone,
                    PresentAddress = entity.PresentAddress,
                    PermanentAddress = entity.PermanentAddress,
                    Awards = entity.Awards,
                    UserId = entity.UserId,
                    DateOfBirth = entity.DateOfBirth,
                    Experience = entity.Experience,
                    ImageUrl = entity.ImageUrl,
                    DoctorChamberRelations = entity.DoctorChamberRelations,
                    DoctorDegreeRelations = entity.DoctorDegreeRelations,
                    DoctorSpecialtyRelations = entity.DoctorSpecialtyRelations
                };
                _doctorUnitOfWork.DoctorRepository.Add(newEntity);
                return _doctorUnitOfWork.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool AddByAdmin(Doctor entity)
        {
            try
            {
                var newEntity = new Doctor()
                {
                    FathersName = entity.FathersName,
                    MothersName = entity.MothersName,
                    GenderId = entity.GenderId,
                    BloodGroupId = entity.BloodGroupId,
                    Designation = entity.Designation,
                    Description = entity.Description,
                    Phone = entity.Phone,
                    PresentAddress = entity.PresentAddress,
                    PermanentAddress = entity.PermanentAddress,
                    Awards = entity.Awards,
                    User = entity.User,
                    DateOfBirth = entity.DateOfBirth,
                    Experience = entity.Experience,
                    ImageUrl = entity.ImageUrl,
                    DoctorChamberRelations = entity.DoctorChamberRelations,
                    DoctorDegreeRelations = entity.DoctorDegreeRelations,
                    DoctorSpecialtyRelations = entity.DoctorSpecialtyRelations
                };

                //----------Auto Save-------------
                newEntity.User.IsEmailVerified = true;
                newEntity.User.Password = CustomCrypto.Hash(CustomName.DoctorDefaultPassword);
                newEntity.User.UserRoleId = (int)CustomEnum.UserType.Doctor;

                _doctorUnitOfWork.DoctorRepository.Add(newEntity);
                return _doctorUnitOfWork.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public int ActiveCount()
        {
            return _doctorUnitOfWork.DoctorRepository.ActiveCount();
        }

        public Doctor GetByUserId(int userId)
        {
            return _doctorUnitOfWork.DoctorRepository.GetByUserId(userId);
        }

        public Doctor GetById(int id)
        {
            return _doctorUnitOfWork.DoctorRepository.GetById(id);
        }

        public string GetDoctorNameById(int id)
        {
            return _doctorUnitOfWork.DoctorRepository.GetById(id).User.Name;
        }

        public bool Update(Doctor entity)
        {
            try
            {
                var existingDoctor = _doctorUnitOfWork.DoctorRepository.GetById(entity.Id);

                existingDoctor.User.Name = entity.User.Name;
                existingDoctor.FathersName = entity.FathersName;
                existingDoctor.MothersName = entity.MothersName;
                existingDoctor.GenderId = entity.GenderId;
                existingDoctor.BloodGroupId = entity.BloodGroupId;
                existingDoctor.Designation = entity.Designation;
                existingDoctor.Description = entity.Description;
                existingDoctor.Phone = entity.Phone;
                existingDoctor.PresentAddress = entity.PresentAddress;
                existingDoctor.PermanentAddress = entity.PermanentAddress;
                existingDoctor.Awards = entity.Awards;
                existingDoctor.DateOfBirth = entity.DateOfBirth;
                existingDoctor.Experience = entity.Experience;
                existingDoctor.ImageUrl = String.IsNullOrEmpty(entity.ImageUrl) ? existingDoctor.ImageUrl : entity.ImageUrl;

                // ...............remove previous relational data.............
                _doctorUnitOfWork.DoctorRepository.DoctorChamberRelationsDeleteRange(existingDoctor.DoctorChamberRelations);
                _doctorUnitOfWork.DoctorRepository.DoctorDegreeRelationsDeleteRange(existingDoctor.DoctorDegreeRelations);
                _doctorUnitOfWork.DoctorRepository.DoctorSpecialtyRelationsDeleteRange(existingDoctor.DoctorSpecialtyRelations);

                existingDoctor.DoctorChamberRelations = entity.DoctorChamberRelations;
                existingDoctor.DoctorDegreeRelations = entity.DoctorDegreeRelations;
                existingDoctor.DoctorSpecialtyRelations = entity.DoctorSpecialtyRelations;

                _doctorUnitOfWork.DoctorRepository.Update(existingDoctor);
                return _doctorUnitOfWork.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public IEnumerable<Doctor> GetAllByArea(string term)
        {
            return _doctorUnitOfWork.DoctorRepository.
                Get(x => x.DoctorChamberRelations.Select(y => y.Chamber.Name.ToLower()).Contains(term.ToLower()));
        }

        public bool IsEmailExist(string email)
        {
            return _userService.IsEmailExist(email);
        }

        public IEnumerable<Doctor> GetAllBySpecialty(string term)
        {
            return _doctorUnitOfWork.DoctorRepository.
                Get(x => x.DoctorSpecialtyRelations.Select(y => y.Specialty.Name.ToLower()).Contains(term.ToLower()));
        }

        public IEnumerable<Doctor> GetAllByName(string term)
        {
            return _doctorUnitOfWork.DoctorRepository.Get(x => x.User.Name.ToLower().Contains(term.ToLower()));
        }

        public IEnumerable<string> GetAllDoctorName(string term)
        {
            return _doctorUnitOfWork.DoctorRepository.Get(x => x.User.Name.ToLower().Contains(term.ToLower())).Select(y => y.User.Name);
        }

        public IEnumerable<Doctor> GetAllDoctors(string area, string specialty, string name)
        {
            return _doctorUnitOfWork.DoctorRepository.GetAllDoctors(area, specialty, name);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _doctorUnitOfWork.DoctorRepository.GetAll();
        }

        public IEnumerable<Doctor> GetAll(string name, byte? status)
        {
            var data = _doctorUnitOfWork.DoctorRepository.Get(x => true);
            data = string.IsNullOrEmpty(name) ? data : data.Where(x => x.User.Name.ToLower().Contains(name.ToLower()));
            data = status == null ? data : data.Where(x => x.Status == status);
            return data.OrderByDescending(x => (x.UpdatedAt == null ? x.CreatedAt : x.UpdatedAt));
        }

        public bool ChangeStatus(int id)
        {
            var doctor = _doctorUnitOfWork.DoctorRepository.GetById(id);
            doctor.Status = doctor.Status == (byte)CustomEnum.Status.Active ?
                (byte)CustomEnum.Status.Inactive : (byte)CustomEnum.Status.Active;
            doctor.UpdatedAt = DateTime.Now;
            return _doctorUnitOfWork.Save();
        }
    }
}
