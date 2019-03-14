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
    }
}
