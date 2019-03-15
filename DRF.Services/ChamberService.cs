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

        public IEnumerable<Chamber> GetAll(string name, byte? status)
        {
            var data = _chamberUnitOfWork.ChamberRepository.Get(x => true);
            data = string.IsNullOrEmpty(name) ? data : data.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            data = status == null ? data : data.Where(x => x.Status == status);
            return data.OrderByDescending(x => (x.UpdatedAt == null ? x.CreatedAt : x.UpdatedAt));
        }

        public bool ChangeStatus(int id)
        {
            var chamber = _chamberUnitOfWork.ChamberRepository.GetById(id);
            chamber.Status = chamber.Status == (byte)CustomEnum.Status.Active ?
                (byte)CustomEnum.Status.Inactive : (byte)CustomEnum.Status.Active;
            chamber.UpdatedAt = DateTime.Now;
            return _chamberUnitOfWork.Save();
        }

        public bool AddOrUpdate(Chamber chamber)
        {
            if (chamber.Id == 0)
            {
                var newChamber = new Chamber()
                {
                    Name = chamber.Name,
                    Address = chamber.Address,
                    AreaId = chamber.AreaId,
                    Status = (byte)CustomEnum.Status.Active,
                    CreatedAt = DateTime.Now
                };
                _chamberUnitOfWork.ChamberRepository.Add(newChamber);
            }
            else
            {
                var existChamber = _chamberUnitOfWork.ChamberRepository.GetById(chamber.Id);
                existChamber.Name = chamber.Name;
                existChamber.Address = chamber.Address;
                existChamber.AreaId = chamber.AreaId;
                existChamber.UpdatedAt = DateTime.Now;
                _chamberUnitOfWork.ChamberRepository.Update(existChamber);
            }

            return _chamberUnitOfWork.Save();
        }
    }
}
