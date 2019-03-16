using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRF.Entities;
using DRF.Services;

namespace DRF.Web.Areas.Admin.Models
{
    public class AreaModel
    {
        private AreaService _areaService;
        private CityService _cityService;

        public AreaModel()
        {
            _areaService = new AreaService();
            _cityService = new CityService();
        }

        public IEnumerable<Area> GetAll(string name, byte? status)
        {
            return _areaService.GetAll(name, status);
        }

        public bool ChangeStatus(int id)
        {
            return _areaService.ChangeStatus(id);
        }

        public IEnumerable<City> GetAllCity()
        {
            return _cityService.GetAll();
        }

        public bool AddOrUpdate(int newAreaId, int newAreaCityId, string newAreaName)
        {
            var area = new Area()
            {
                Id = newAreaId,
                CityId = newAreaCityId,
                Name = newAreaName
            };

            return _areaService.AddOrUpdate(area);
        }
    }
}