using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRF.Web.Areas.Admin.Models;

namespace DRF.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private HomeModel _homeModel;

        public HomeController()
        {
            _homeModel = new HomeModel();
        }

        // GET: Admin/Home
        public ActionResult Index()
        {
            var model = _homeModel;
            return View(model);
        }

        public ActionResult GetAllAppointmentChartData(int id)
        {
            var data = _homeModel.GetAllAppointmentChartData().ToList();
            return Json( data, JsonRequestBehavior.AllowGet);
        }
    }
}