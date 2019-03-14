using DRF.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DRF.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DegreeController : Controller
    {
        private DegreeModel _degreeModel;

        public DegreeController()
        {
            _degreeModel = new DegreeModel();
        }

        // GET: Admin/Degree
        public ActionResult Index()
        {
            return View();
        }
    }
}