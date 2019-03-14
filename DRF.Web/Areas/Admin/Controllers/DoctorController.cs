using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRF.Web.Areas.Admin.Models;

namespace DRF.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DoctorController : Controller
    {
        private DoctorModel _doctorModel;

        public DoctorController()
        {
            _doctorModel = new DoctorModel();
        }

        // GET: Admin/Doctor
        public ActionResult Index()
        {
            return View();
        }
    }
}