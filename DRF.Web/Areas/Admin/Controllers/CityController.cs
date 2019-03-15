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
    public class CityController : Controller
    {
        private CityModel _cityModel;

        public CityController()
        {
            _cityModel = new CityModel();
        }

        // GET: Admin/City
        public ActionResult Index(CitySearchModel model)
        {
            model = model ?? new CitySearchModel();
            var cityCollection = _cityModel.GetAll(model.Name, model.Status).ToList();
            model.CityCollection = cityCollection.ToPagedList(model.Page, model.PageSize);
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(int NewCityId, string NewCityName)
        {
            var isSaved = _cityModel.AddOrUpdate(NewCityId, NewCityName);
            if (isSaved)
            {
                TempData[CustomMessage.Success] = "City successfully " + (NewCityId == 0 ? "added" : "updated");
            }
            else
            {
                TempData[CustomMessage.Failure] = "City " + (NewCityId == 0 ? "add" : "update") + " failed";
            }
            return RedirectToAction("Index");
        }

        public ActionResult ChangeStatus(int id)
        {
            var isChanged = _cityModel.ChangeStatus(id);
            if (isChanged)
            {
                TempData[CustomMessage.Success] = "City Status successfully changed";
            }
            else
            {
                TempData[CustomMessage.Failure] = "City Status change failed";
            }
            return RedirectToAction("Index");
        }
    }
}