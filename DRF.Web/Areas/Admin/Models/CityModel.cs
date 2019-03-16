using DRF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRF.Entities;

namespace DRF.Web.Areas.Admin.Models
{
    public class CityModel
    {
        private CityService _cityService;

        public CityModel()
        {
            _cityService = new CityService();
        }

        public IEnumerable<City> GetAll(string name, byte? status)
        {
            return _cityService.GetAll(name, status);
        }

        public bool ChangeStatus(int id)
        {
            return _cityService.ChangeStatus(id);
        }

        public bool AddOrUpdate(int newCityId, string newCityName)
        {
            var city = new City()
            {
                Id = newCityId,
                Name = newCityName
            };

            return _cityService.AddOrUpdate(city);
        }
    }
}