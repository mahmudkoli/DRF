using DRF.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DRF.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ChamberController : Controller
    {
        private ChamberModel _chamberModel;

        public ChamberController()
        {
            _chamberModel = new ChamberModel();
        }

        // GET: Admin/Chamber
        public ActionResult Index()
        {
            return View();
        }
    }
}