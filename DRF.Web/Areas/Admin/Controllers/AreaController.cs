using DRF.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DRF.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AreaController : Controller
    {
        private AreaModel _areaModel;

        public AreaController()
        {
            _areaModel = new AreaModel();
        }

        // GET: Admin/Area
        public ActionResult Index()
        {
            return View();
        }
    }
}