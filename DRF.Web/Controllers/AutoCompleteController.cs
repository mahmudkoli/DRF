using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRF.Services;

namespace DRF.Web.Controllers
{
    public class AutoCompleteController : Controller
    {
        private DoctorService _doctorService;
        private SpecialtyService _specialtyService;
        private AreaService _areaService;

        public AutoCompleteController()
        {
            _doctorService = new DoctorService();
            _specialtyService = new SpecialtyService();
            _areaService = new AreaService();
        }

        public JsonResult GetAllDoctorName(string term)
        {
            var data = _doctorService.GetAllDoctorName(term);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllSpecialtyName(string term)
        {
            var data = _specialtyService.GetAllSpecialtyName(term);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllAreaName(string term)
        {
            var data = _areaService.GetAllAreaName(term);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}