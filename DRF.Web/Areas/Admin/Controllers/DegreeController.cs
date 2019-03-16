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
    public class DegreeController : Controller
    {
        private DegreeModel _degreeModel;

        public DegreeController()
        {
            _degreeModel = new DegreeModel();
        }

        // GET: Admin/Degree
        public ActionResult Index(DegreeSearchModel model)
        {
            model = model ?? new DegreeSearchModel();
            var degreeCollection = _degreeModel.GetAll(model.Name, model.Status).ToList();
            model.DegreeCollection = degreeCollection.ToPagedList(model.Page, model.PageSize);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(int NewDegreeId, string NewDegreeName, string NewDegreeDetails)
        {
            var isSaved = _degreeModel.AddOrUpdate(NewDegreeId, NewDegreeName, NewDegreeDetails);
            if (isSaved)
            {
                TempData[CustomMessage.Success] = "Degree successfully " + (NewDegreeId == 0 ? "added" : "updated");
            }
            else
            {
                TempData[CustomMessage.Failure] = "Degree " + (NewDegreeId == 0 ? "add" : "update") + " failed";
            }
            return RedirectToAction("Index");
        }

        public ActionResult ChangeStatus(int id)
        {
            var isChanged = _degreeModel.ChangeStatus(id);
            if (isChanged)
            {
                TempData[CustomMessage.Success] = "Degree Status successfully changed";
            }
            else
            {
                TempData[CustomMessage.Failure] = "Degree Status change failed";
            }
            return RedirectToAction("Index");
        }
    }
}