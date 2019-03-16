using DRF.Entities;
using DRF.Repository;
using DRF.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRF.Services
{
    public class DataService
    {
        private DataUnitOfWork _dataUnitOfWork;

        public DataService()
        {
            _dataUnitOfWork = new DataUnitOfWork(new DRFDbContext());
        }

        public IEnumerable<Gender> GetAllGender()
        {
            return _dataUnitOfWork.GenderRepository.GetAll();
        }

        public IEnumerable<BloodGroup> GetAllBloodGroup()
        {
            return _dataUnitOfWork.BloodGroupRepository.GetAll();
        }
    }
}
