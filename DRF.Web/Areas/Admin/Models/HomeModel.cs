using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DRF.Services;

namespace DRF.Web.Areas.Admin.Models
{
    public class HomeModel
    {
        public int TotalDoctorCount { get; set; }
        public int TotalPatientCount { get; set; }
        public int TotalCityCount { get; set; }
        public int TotalAreaCount { get; set; }
        public int TotalChamberCount { get; set; }

        private DoctorService _doctorService;
        private PatientService _patientService;
        private CityService _cityService;
        private AreaService _areaService;
        private ChamberService _chamberService;

        public HomeModel()
        {
            _doctorService = new DoctorService();
            _patientService = new PatientService();
            _cityService = new CityService();
            _areaService = new AreaService();
            _chamberService = new ChamberService();

            TotalDoctorCount = _doctorService.ActiveCount();
            TotalPatientCount = _patientService.ActiveCount();
            TotalCityCount = _cityService.ActiveCount();
            TotalAreaCount = _areaService.ActiveCount();
            TotalChamberCount = _chamberService.ActiveCount();
        }
    }
}