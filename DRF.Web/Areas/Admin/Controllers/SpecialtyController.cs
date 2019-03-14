using DRF.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DRF.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SpecialtyController : Controller
    {
        private SpecialtyModel _specialtyModel;

        public SpecialtyController()
        {
            _specialtyModel = new SpecialtyModel();
        }

        // GET: Admin/Specialty
        public ActionResult Index()
        {
            return View();
        }
    }
}