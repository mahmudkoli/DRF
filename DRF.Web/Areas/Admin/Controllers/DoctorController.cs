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
    }
}