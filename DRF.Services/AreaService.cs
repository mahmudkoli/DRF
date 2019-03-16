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
    public class AreaService
    {
        private AreaUnitOfWork _areaUnitOfWork;

        public AreaService()
        {
            _areaUnitOfWork = new AreaUnitOfWork(new DRFDbContext());
        }

        public IEnumerable<Area> GetAll()
        {
            return _areaUnitOfWork.AreaRepository.GetAll();
        }

        public IEnumerable<string> GetAllAreaName(string term)
        {
            return _areaUnitOfWork.AreaRepository.Get(x => x.Name.ToLower().Contains(term.ToLower()))
                .Select(y => y.Name);
        }

        public IEnumerable<Area> GetAll(string name, byte? status)
        {
            var data = _areaUnitOfWork.AreaRepository.Get(x => true);
            data = string.IsNullOrEmpty(name) ? data : data.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            data = status == null ? data : data.Where(x => x.Status == status);
            return data.OrderByDescending(x => (x.UpdatedAt == null ? x.CreatedAt : x.UpdatedAt));
        }

        public int ActiveCount()
        {
            return _areaUnitOfWork.AreaRepository.ActiveCount();
        }

        public bool ChangeStatus(int id)
        {
            var area = _areaUnitOfWork.AreaRepository.GetById(id);
            area.Status = area.Status == (byte)CustomEnum.Status.Active ?
                (byte)CustomEnum.Status.Inactive : (byte)CustomEnum.Status.Active;
            area.UpdatedAt = DateTime.Now;
            return _areaUnitOfWork.Save();
        }

        public bool AddOrUpdate(Area area)
        {
            if (area.Id == 0)
            {
                var newArea = new Area()
                {
                    Name = area.Name,
                    CityId = area.CityId,
                    Status = (byte)CustomEnum.Status.Active,
                    CreatedAt = DateTime.Now
                };
                _areaUnitOfWork.AreaRepository.Add(newArea);
            }
            else
            {
                var existArea = _areaUnitOfWork.AreaRepository.GetById(area.Id);
                existArea.Name = area.Name;
                existArea.CityId = area.CityId;
                existArea.UpdatedAt = DateTime.Now;
                _areaUnitOfWork.AreaRepository.Update(existArea);
            }

            return _areaUnitOfWork.Save();
        }
    }
}
