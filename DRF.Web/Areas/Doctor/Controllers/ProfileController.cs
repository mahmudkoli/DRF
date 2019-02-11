using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Web;
using System.Web.Mvc;
using DRF.Common;
using DRF.Services;
using DRF.Web.Areas.Doctor.Models;

namespace DRF.Web.Areas.Doctor.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class ProfileController : Controller
    {
        private DoctorModel _doctorModel;
        private bool _isExistDoctor;

        public ProfileController()
        {
            _doctorModel = new DoctorModel();
            _isExistDoctor = _doctorModel.IsExist();
        }

        public ActionResult Index()
        {
            if (!_isExistDoctor)
            {
                TempData[CustomMessage.Info] = "Please add your profile information";
                return RedirectToAction("Create");
            }

            _doctorModel = new DoctorModel(0);
            return View(_doctorModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (_isExistDoctor)
            {
                return RedirectToAction("Index");
            }
            return View(_doctorModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DoctorModel model)
        {
            if (ModelState.IsValid)
            {
                var isSaved = model.Add();
                if (isSaved)
                {
                    TempData[CustomMessage.Success] = "Profile successfully created";
                    return RedirectToAction("Index");
                }
            }

            TempData[CustomMessage.Failure] = "Profile create failed";
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            _doctorModel = new DoctorModel(0);
            return View(_doctorModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Exclude = "User.Email,User.Password,User.UserRoleId")] DoctorModel model)
        {
            ModelState.Remove("User.Email");
            ModelState.Remove("User.Password");
            ModelState.Remove("User.UserRoleId");

            if (ModelState.IsValid)
            {
                var isUpdated = model.Update();
                if (isUpdated)
                {
                    TempData[CustomMessage.Success] = "Profile successfully updated";
                    return RedirectToAction("Index");
                }
            }

            TempData[CustomMessage.Failure] = "Profile update failed";
            return View(model);
        }
    }
}