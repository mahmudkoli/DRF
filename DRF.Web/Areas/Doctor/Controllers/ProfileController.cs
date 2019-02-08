using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRF.Services;
using DRF.Web.Areas.Doctor.Models;

namespace DRF.Web.Areas.Doctor.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class ProfileController : Controller
    {
        private DoctorModel _doctorModel;
        public ProfileController()
        {
            _doctorModel = new DoctorModel();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(_doctorModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DoctorModel model)
        {
            return View();
        }
    }
}