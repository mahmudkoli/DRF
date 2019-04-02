using DRF.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DRF.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private PatientModel _patientModel;

        public ProfileController()
        {
            _patientModel = new PatientModel();
        }

        // GET: Profile
        public ActionResult Index()
        {
            _patientModel = new PatientModel(0);
            return View(_patientModel);
        }

        public ActionResult EditProfile()
        {
            _patientModel = new PatientModel(0);
            return View(_patientModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(PatientModel model)
        {
            ModelState.Remove("User.Email");
            ModelState.Remove("User.Password");
            ModelState.Remove("User.UserRoleId");

            if (ModelState.IsValid)
            {
                var isUpdated = model.Update();
                if (isUpdated)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }


    }
}