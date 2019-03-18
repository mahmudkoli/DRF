using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRF.Common;
using DRF.Web.Areas.Admin.Models;
//using DRF.Web.Models;
using PagedList;

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
        public ActionResult Index(PatientSearchModel model)
        {
            model = model ?? new PatientSearchModel();
            var patientCollection = _patientModel.GetAll(model.Name, model.Status).ToList();
            model.PatientCollection = patientCollection.ToPagedList(model.Page, model.PageSize);
            return View(model);
        }

        public ActionResult ChangeStatus(int id)
        {
            var isChanged = _patientModel.ChangeStatus(id);
            if (isChanged)
            {
                TempData[CustomMessage.Success] = "Patient Status successfully changed";
            }
            else
            {
                TempData[CustomMessage.Failure] = "Patient Status change failed";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View(_patientModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PatientModel model)
        {
            ModelState.Remove("User.Password");
            ModelState.Remove("User.UserRoleId");

            if (ModelState.IsValid)
            {
                if (model.IsEmailExist(model.User.Email))
                {
                    TempData[CustomMessage.Failure] = "Email already exist!";
                    ModelState.AddModelError("User.Email", "Email already exist!");
                    return View(model);
                }

                var isSaved = model.Add();
                if (isSaved)
                {
                    TempData[CustomMessage.Success] = "Patient Profile successfully created";
                    return RedirectToAction("Index");
                }
            }

            TempData[CustomMessage.Failure] = "Patient Profile create failed";
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            _patientModel = new PatientModel(id);
            return View(_patientModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PatientModel model)
        {
            ModelState.Remove("User.Email");
            ModelState.Remove("User.Password");
            ModelState.Remove("User.UserRoleId");

            if (ModelState.IsValid)
            {
                var isUpdated = model.Update();
                if (isUpdated)
                {
                    TempData[CustomMessage.Success] = "Patient Profile successfully updated";
                    return RedirectToAction("Index");
                }
            }

            TempData[CustomMessage.Failure] = "Patient Profile update failed";
            return View(model);
        }

        public ActionResult Details(int id)
        {
            _patientModel = new PatientModel(id);
            return View(_patientModel);
        }
    }
}