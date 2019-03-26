using DRF.Common;
using DRF.Web.Areas.Doctor.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DRF.Web.Areas.Doctor.Controllers
{
    [Authorize(Roles = "Doctor")]
    [RedirectingAction]
    public class VacationController : Controller
    {
        private bool _isExistDoctor;
        private VacationModel _vacationModel;

        public VacationController()
        {
            _isExistDoctor = AuthenticatedDoctorUserModel.IsExistDoctor();
            if (_isExistDoctor)
            {
                _vacationModel = new VacationModel();
            }
        }

        // GET: Doctor/Vacation
        public ActionResult Index(VacationSearchModel model)
        {
            model = model ?? new VacationSearchModel();
            var vacations = _vacationModel.GetAllVacations(model.Chamber, model.FromDate, model.ToDate).ToList();
            model.VacationCollection = vacations.ToPagedList(model.Page, model.PageSize);
            model.ChamberCollection = _vacationModel.GetAllChamberByDoctorId();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(_vacationModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VacationModel model)
        {
            if (ModelState.IsValid)
            {
                var isSaved = model.Add();
                if (isSaved)
                {
                    TempData[CustomMessage.Success] = "Schedule successfully created";
                    return RedirectToAction("Index");
                }
            }

            TempData[CustomMessage.Failure] = "Schedule create failed";
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var _vacationModel = new VacationModel(id);
            return View(_vacationModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VacationModel model)
        {
            if (ModelState.IsValid)
            {
                var isSaved = model.Update();
                if (isSaved)
                {
                    TempData[CustomMessage.Success] = "Schedule successfully updated";
                    return RedirectToAction("Index");
                }
            }

            TempData[CustomMessage.Failure] = "Schedule update failed";
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var isDeleted = _vacationModel.Delete(id); if (isDeleted)
            {
                TempData[CustomMessage.Success] = "Vacation successfully deleted";
            }
            else
            {
                TempData[CustomMessage.Failure] = "Vacation delete failed";
            }

            return Json(new { data = isDeleted }, JsonRequestBehavior.AllowGet);
        }
    }
}