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
    public class ChamberService
    {
        private ChamberUnitOfWork _chamberUnitOfWork;

        public ChamberService()
        {
            _chamberUnitOfWork = new ChamberUnitOfWork(new DRFDbContext());
        }

        public IEnumerable<Chamber> GetAll()
        {
            return _chamberUnitOfWork.ChamberRepository.GetAll();
        }

        public IEnumerable<Chamber> GetAllByDoctorId(int doctorId)
        {
            return _chamberUnitOfWork.ChamberRepository.GetAllByDoctorId(doctorId);
        }

        public Chamber GetById(int id)
        {
            return _chamberUnitOfWork.ChamberRepository.GetById(id);
        }
        public string GetChamberNameById(int id)
        {
            return _chamberUnitOfWork.ChamberRepository.GetById(id).Name;
        }
    }
}
