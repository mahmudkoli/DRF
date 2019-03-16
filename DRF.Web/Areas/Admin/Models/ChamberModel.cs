using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRF.Entities;
using DRF.Services;

namespace DRF.Web.Areas.Admin.Models
{
    public class ChamberModel
    {
        private ChamberService _chamberService;
        private AreaService _areaService;

        public ChamberModel()
        {
            _chamberService = new ChamberService();
            _areaService = new AreaService();
        }

        public IEnumerable<Chamber> GetAll(string name, byte? status)
        {
            return _chamberService.GetAll(name, status);
        }

        public bool ChangeStatus(int id)
        {
            return _chamberService.ChangeStatus(id);
        }

        public IEnumerable<Area> GetAllArea()
        {
            return _areaService.GetAll();
        }

        public bool AddOrUpdate(int newChamberId, int newChamberAreaId, string newChamberName, string newChamberAddress)
        {
            var chamber = new Chamber()
            {
                Id = newChamberId,
                AreaId = newChamberAreaId,
                Name = newChamberName,
                Address = newChamberAddress
            };

            return _chamberService.AddOrUpdate(chamber);
        }
    }
}