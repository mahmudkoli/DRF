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

        public bool AddOrUpdate(NewChamberModel model)
        {
            var chamber = new Chamber()
            {
                Id = model.NewChamberId,
                AreaId = model.NewChamberAreaId,
                Name = model.NewChamberName,
                Address = model.NewChamberAddress,
                Map = new Map()
                {
                    Lat = model.NewChamberMapLat,
                    Long = model.NewChamberMapLong
                }
            };

            return _chamberService.AddOrUpdate(chamber);
        }
    }

    public class NewChamberModel
    {
        public int NewChamberId { get; set; }
        public int NewChamberAreaId { get; set; }
        public string NewChamberName { get; set; }
        public string NewChamberAddress { get; set; }
        public string NewChamberMapLat { get; set; }
        public string NewChamberMapLong { get; set; }
    }
}