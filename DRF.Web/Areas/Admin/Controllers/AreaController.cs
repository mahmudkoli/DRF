using DRF.Common;
using DRF.Web.Areas.Admin.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DRF.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AreaController : Controller
    {
        private AreaModel _areaModel;

        public AreaController()
        {
            _areaModel = new AreaModel();
        }

        // GET: Admin/Area
        public ActionResult Index(AreaSearchModel model)
        {
            model = model ?? new AreaSearchModel();
            var areaCollection = _areaModel.GetAll(model.Name, model.Status).ToList();
            model.AreaCollection = areaCollection.ToPagedList(model.Page, model.PageSize);
            ViewBag.CitySelectList = new SelectList(_areaModel.GetAllCity(), "Id", "Name");
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(int NewAreaId, int NewAreaCityId, string NewAreaName)
        {
            var isSaved = _areaModel.AddOrUpdate(NewAreaId, NewAreaCityId, NewAreaName);
            if (isSaved)
            {
                TempData[CustomMessage.Success] = "Area successfully " + (NewAreaId == 0 ? "added":"updated");
            }
            else
            {
                TempData[CustomMessage.Failure] = "Area " + (NewAreaId == 0 ? "add":"update") + " failed";
            }
            return RedirectToAction("Index");
        }

        public ActionResult ChangeStatus(int id)
        {
            var isChanged = _areaModel.ChangeStatus(id);
            if (isChanged)
            {
                TempData[CustomMessage.Success] = "Area Status successfully changed";
            }
            else
            {
                TempData[CustomMessage.Failure] = "Area Status change failed";
            }
            return RedirectToAction("Index");
        }
    }
}