using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRF.Services;

namespace DRF.Web.Areas.Admin.Models
{
    public class DoctorModel
    {
        private DoctorService _doctorService;

        public DoctorModel()
        {
            _doctorService = new DoctorService();
        }
    }
}