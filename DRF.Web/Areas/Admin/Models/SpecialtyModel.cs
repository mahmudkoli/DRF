using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRF.Services;

namespace DRF.Web.Areas.Admin.Models
{
    public class SpecialtyModel
    {
        private SpecialtyService _specialtyService;

        public SpecialtyModel()
        {
            _specialtyService = new SpecialtyService();
        }
    }
}