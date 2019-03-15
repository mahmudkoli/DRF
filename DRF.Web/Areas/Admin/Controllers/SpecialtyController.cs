using DRF.Common;
using DRF.Web.Areas.Admin.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DRF.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SpecialtyController : Controller
    {
        private SpecialtyModel _specialtyModel;

        public SpecialtyController()
        {
            _specialtyModel = new SpecialtyModel();
        }

        // GET: Admin/Specialty
        public ActionResult Index(SpecialtySearchModel model)
        {
            model = model ?? new SpecialtySearchModel();
            var specialtyCollection = _specialtyModel.GetAll(model.Name, model.Status).ToList();
            model.SpecialtyCollection = specialtyCollection.ToPagedList(model.Page, model.PageSize);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(int NewSpecialtyId, string NewSpecialtyName, string NewSpecialtyDisease, string NewSpecialtyDetails)
        {
            var isSaved = _specialtyModel.AddOrUpdate(NewSpecialtyId, NewSpecialtyName, NewSpecialtyDisease, NewSpecialtyDetails);
            if (isSaved)
            {
                TempData[CustomMessage.Success] = "Specialty successfully " + (NewSpecialtyId == 0 ? "added" : "updated");
            }
            else
            {
                TempData[CustomMessage.Failure] = "Specialty " + (NewSpecialtyId == 0 ? "add" : "update") + " failed";
            }
            return RedirectToAction("Index");
        }

        public ActionResult ChangeStatus(int id)
        {
            var isChanged = _specialtyModel.ChangeStatus(id);
            if (isChanged)
            {
                TempData[CustomMessage.Success] = "Specialty Status successfully changed";
            }
            else
            {
                TempData[CustomMessage.Failure] = "Specialty Status change failed";
            }
            return RedirectToAction("Index");
        }
    }
}