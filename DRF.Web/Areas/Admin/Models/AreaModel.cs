using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRF.Services;

namespace DRF.Web.Areas.Admin.Models
{
    public class AreaModel
    {
        private AreaService _areaService;

        public AreaModel()
        {
            _areaService = new AreaService();
        }
    }
}