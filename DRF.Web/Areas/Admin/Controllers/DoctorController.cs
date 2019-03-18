using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRF.Common;
using DRF.Web.Areas.Admin.Models;
using PagedList;

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
        public ActionResult Index(DoctorSearchModel model)
        {
            model = model ?? new DoctorSearchModel();
            var doctorCollection = _doctorModel.GetAll(model.Name, model.Status).ToList();
            model.DoctorCollection = doctorCollection.ToPagedList(model.Page, model.PageSize);
            return View(model);
        }

        public ActionResult ChangeStatus(int id)
        {
            var isChanged = _doctorModel.ChangeStatus(id);
            if (isChanged)
            {
                TempData[CustomMessage.Success] = "Doctor Status successfully changed";
            }
            else
            {
                TempData[CustomMessage.Failure] = "Doctor Status change failed";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View(_doctorModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DoctorModel model)
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
                    TempData[CustomMessage.Success] = "Doctor Profile successfully created";
                    return RedirectToAction("Index");
                }
            }

            TempData[CustomMessage.Failure] = "Doctor Profile create failed";
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            _doctorModel = new DoctorModel(id);
            return View(_doctorModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DoctorModel model)
        {
            ModelState.Remove("User.Email");
            ModelState.Remove("User.Password");
            ModelState.Remove("User.UserRoleId");

            if (ModelState.IsValid)
            {
                var isUpdated = model.Update();
                if (isUpdated)
                {
                    TempData[CustomMessage.Success] = "Doctor Profile successfully updated";
                    return RedirectToAction("Index");
                }
            }

            TempData[CustomMessage.Failure] = "Doctor Profile update failed";
            return View(model);
        }

        public ActionResult Details(int id)
        {
            _doctorModel = new DoctorModel(id);
            return View(_doctorModel);
        }
    }
}