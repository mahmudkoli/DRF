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
    public class DoctorService
    {
        private DoctorUnitOfWork _doctorUnitOfWork;

        public DoctorService()
        {
            _doctorUnitOfWork = new DoctorUnitOfWork(new DRFDbContext());
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

        public Doctor GetByUserId(int userId)
        {
            return _doctorUnitOfWork.DoctorRepository.GetByUserId(userId);
        }

        public Doctor GetById(int id)
        {
            return _doctorUnitOfWork.DoctorRepository.GetById(id);
        }
    }
}
