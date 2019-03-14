using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRF.Web.Areas.Admin.Models;
using DRF.Web.Models;

namespace DRF.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PatientController : Controller
    {
        private PatientModel _patientModel;

        public PatientController()
        {
            _patientModel = new PatientModel();
        }

        // GET: Admin/Patient
        public ActionResult Index()
        {
            return View();
        }
    }
}