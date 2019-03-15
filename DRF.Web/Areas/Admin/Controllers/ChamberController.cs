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
    public class ChamberController : Controller
    {
        private ChamberModel _chamberModel;

        public ChamberController()
        {
            _chamberModel = new ChamberModel();
        }

        // GET: Admin/Chamber
        public ActionResult Index(ChamberSearchModel model)
        {
            model = model ?? new ChamberSearchModel();
            var chamberCollection = _chamberModel.GetAll(model.Name, model.Status).ToList();
            model.ChamberCollection = chamberCollection.ToPagedList(model.Page, model.PageSize);
            ViewBag.AreaSelectList = new SelectList(_chamberModel.GetAllArea(), "Id", "Name");
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(int NewChamberId, int NewChamberAreaId, string NewChamberName, string NewChamberAddress)
        {
            var isSaved = _chamberModel.AddOrUpdate(NewChamberId, NewChamberAreaId, NewChamberName, NewChamberAddress);
            if (isSaved)
            {
                TempData[CustomMessage.Success] = "Chamber successfully " + (NewChamberId == 0 ? "added" : "updated");
            }
            else
            {
                TempData[CustomMessage.Failure] = "Chamber " + (NewChamberId == 0 ? "add" : "update") + " failed";
            }
            return RedirectToAction("Index");
        }

        public ActionResult ChangeStatus(int id)
        {
            var isChanged = _chamberModel.ChangeStatus(id);
            if (isChanged)
            {
                TempData[CustomMessage.Success] = "Chamber Status successfully changed";
            }
            else
            {
                TempData[CustomMessage.Failure] = "Chamber Status change failed";
            }
            return RedirectToAction("Index");
        }
    }
}