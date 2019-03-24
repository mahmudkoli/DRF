using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRF.Common;
using DRF.Web.Areas.Doctor.Models;

namespace DRF.Web.Areas.Doctor.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class HomeController : Controller
    {
        private HomeModel _homeModel;
        private bool _isExistDoctor;

        public HomeController()
        {
            _isExistDoctor = AuthenticatedDoctorUserModel.IsExistDoctor();
            if (_isExistDoctor)
            {
                _homeModel = new HomeModel();
            }
        }

        // GET: Doctor/Home
        public ActionResult Index()
        {
            if (!_isExistDoctor)
            {
                TempData[CustomMessage.Info] = "Please add your profile information";
                return RedirectToAction("Create", "Profile");
            }

            return View(_homeModel);
        }

        public ActionResult GetAllAppointmentChartData(int id)
        {
            var data = _homeModel.GetAllAppointmentChartData().ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}