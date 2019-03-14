using DRF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DRF.Web.Areas.Admin.Models
{
    public class CityModel
    {
        private CityService _cityService;

        public CityModel()
        {
            _cityService = new CityService();
        }
    }
}