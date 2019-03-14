using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRF.Services;

namespace DRF.Web.Areas.Admin.Models
{
    public class ChamberModel
    {
        private ChamberService _chamberService;

        public ChamberModel()
        {
            _chamberService = new ChamberService();
        }
    }
}