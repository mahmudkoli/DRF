using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DRF.Common;
using DRF.Web.Areas.Admin.Models;
using DRF.Web.Models;
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
    }
}