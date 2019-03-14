using DRF.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DRF.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CityController : Controller
    {
        private CityModel _cityModel;

        public CityController()
        {
            _cityModel = new CityModel();
        }

        // GET: Admin/City
        public ActionResult Index()
        {
            return View();
        }
    }
}