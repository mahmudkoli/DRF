using DRF.Common;
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
    public class CityService
    {
        private CityUnitOfWork _cityUnitOfWork;

        public CityService()
        {
            _cityUnitOfWork = new CityUnitOfWork(new DRFDbContext());
        }

        public IEnumerable<City> GetAll()
        {
            return _cityUnitOfWork.CityRepository.GetAll();
        }
        public IEnumerable<City> GetAll(string name, byte? status)
        {
            var data = _cityUnitOfWork.CityRepository.Get(x => true);
            data = string.IsNullOrEmpty(name) ? data : data.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            data = status == null ? data : data.Where(x => x.Status == status);
            return data.OrderByDescending(x => (x.UpdatedAt == null ? x.CreatedAt : x.UpdatedAt));
        }

        public bool ChangeStatus(int id)
        {
            var city = _cityUnitOfWork.CityRepository.GetById(id);
            city.Status = city.Status == (byte)CustomEnum.Status.Active ?
                (byte)CustomEnum.Status.Inactive : (byte)CustomEnum.Status.Active;
            city.UpdatedAt = DateTime.Now;
            return _cityUnitOfWork.Save();
        }

        public int ActiveCount()
        {
            return _cityUnitOfWork.CityRepository.ActiveCount();
        }

        public bool AddOrUpdate(City city)
        {
            if (city.Id == 0)
            {
                var newCity = new City()
                {
                    Name = city.Name,
                    Status = (byte)CustomEnum.Status.Active,
                    CreatedAt = DateTime.Now
                };
                _cityUnitOfWork.CityRepository.Add(newCity);
            }
            else
            {
                var existCity = _cityUnitOfWork.CityRepository.GetById(city.Id);
                existCity.Name = city.Name;
                existCity.UpdatedAt = DateTime.Now;
                _cityUnitOfWork.CityRepository.Update(existCity);
            }

            return _cityUnitOfWork.Save();
        }
    }
}
